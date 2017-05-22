using Beian.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beian.Infrastructure.Providers
{
    public class CyclicBuffer
    {
        #region Public Instance Constructors
        public CyclicBuffer(int maxSize)
        {
            if (maxSize < 1)
            {
                throw new ArgumentOutOfRangeException(
                        "newSize", (object)maxSize, "Parameter: newSize, Value: [" + maxSize + "] out of range");
            }
            this.maxSize = maxSize;
            this.logs = new Log[maxSize];
            this.first = 0;
            this.last = 0;
            this.numLogs = 0;
        }
        #endregion Public Instance Constructors

        #region Private Instance Fields

        private Log[] logs;
        private int maxSize;
        private int first;
        private int numLogs;
        private int last;
        #endregion Private Instance Fields

        #region Public Instance Properties
        public int Length
        {
            get
            {
                lock (this)
                {
                    return numLogs;
                }
            }
        }
        public int MaxSize
        {
            get
            {
                lock (this)
                {
                    return maxSize;
                }
            }
        }
        public Log this[int i]
        {
            get
            {
                lock (this)
                {
                    if (i < 0 || i >= numLogs)
                    {
                        return null;
                    }

                    return logs[(first + i) % maxSize];
                }
            }
        }
        #endregion Public Instance Properties

        #region Public Instance Methods
        public void Clear()
        {
            lock (this)
            {
                Array.Clear(logs, 0, logs.Length);

                first = 0;
                last = 0;
                numLogs = 0;
            }
        }

        public Log[] PopAll()
        {
            lock (this)
            {
                Log[] retLogs = new Log[numLogs];
                if (numLogs > 0)
                {
                    if (first < last)
                    {
                        Array.Copy(logs, first, retLogs, 0, numLogs);
                    }
                    else
                    {
                        Array.Copy(logs, first, retLogs, 0, maxSize - first);
                        Array.Copy(logs, 0, retLogs, maxSize - first, last);
                    }
                }

                Clear();

                return retLogs;
            }
        }

        /// <summary>
        /// Appends a <paramref name="log"/> to the buffer.
        /// </summary>
        /// <param name="log">The log to append to the buffer</param>
        /// <returns>The last log of the buffer,if the buffer is full,otherwise <c>null</c></returns>
        public Log Append(Log log)
        {
            if (log == null)
            {
                throw new ArgumentNullException("log");
            }

            lock (this)
            {
                // save the last log
                Log lastLog = logs[last];

                // overwrite the last log position
                logs[last] = log;
                if (++last == maxSize)
                {
                    last = 0;
                }

                if (numLogs < maxSize)
                {
                    numLogs++;
                }
                else if (++first == maxSize)
                {
                    first = 0;
                }

                if (numLogs < maxSize)
                {
                    // Space remaining
                    return null;
                }
                else
                {
                    // Buffer is full
                    return lastLog;
                }
            }
        }
        public void Resize(int newSize)
        {
            lock (this)
            {
                if (newSize < 0)
                {
                    throw new ArgumentOutOfRangeException("newSize out of range");
                }
                if (newSize == numLogs)
                {
                    return;
                }

                Log[] temp = new Log[newSize];
                int loopLength = (newSize < numLogs) ? newSize : numLogs;

                for (int i = 0; i < loopLength; i++)
                {
                    temp[i] = logs[first];
                    logs[first++] = null;
                    if (first == numLogs)
                    {
                        first = 0;
                    }
                }
                logs = temp;
                first = 0;
                numLogs = loopLength;
                maxSize = newSize;

                if (loopLength == newSize)
                {
                    last = 0;
                }
                else
                {
                    last = loopLength;
                }
            }
        }
        #endregion Public Instance Methods
    }
}
