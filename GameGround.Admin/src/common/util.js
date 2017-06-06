
export default {
    formatDate: function (str) { // value is microsoft date string, eg: /Date(1494442633600+0800)/
        alert("formatDate");
        var value = new Date(parseInt(str.replace(/(^.*\()|([+-].*$)/g, '')))
        return value.getFullYear() + '-' + (1 + value.getMonth()) + '-' + value.getDate()
    },
    dateToString:function(date){
        return date.getFullYear()+"-"+(date.getMonth()+1)+"-"+date.getDate();
    }
}
