function DeepCopy(obj) {
    if (typeof (obj) !== 'object') {
        return obj;
    }
    else {
        var clone = {};
        for (var key in obj) {
            clone[key] = DeepCopy(obj[key]);
        }
        return clone;
    }
}