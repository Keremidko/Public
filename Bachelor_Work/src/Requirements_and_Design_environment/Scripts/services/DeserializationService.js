RDE.factory('DeserializationService', function () {

    var deserializeCircularReferences = function (data) {
        var refs = {}, ids = {};
        fillRefs(data, refs);
        fillIds(data, ids);
        mapRefsToIds(refs, ids);
    };

    var fillRefs = function (data, refs) {
        if (typeof data != "object")
            return;
        for (var i in data) {
            var ref = data[i].$ref;
            if (ref != undefined) {
                if (refs[ref] == undefined)
                    refs[ref] = [];
                refs[ref].push({ parent: data, child: i });
            }
            fillRefs(data[i], refs);
        }
    };

    var fillIds = function (data, ids) {
        if (typeof data != "object")
            return;
        if (data.$id != undefined)
            ids[data.$id] = data;
        for (var i in data) {
            var id = data[i].$id;
            if (id != undefined) {
                ids[id] = data[i];
            }
            fillIds(data[i], ids);
        }
    };

    var mapRefsToIds = function (refs, ids) {
        for (var i in refs) {
            for (var j in refs[i]) {
                var parent = refs[i][j].parent;
                var child = refs[i][j].child;
                parent[child] = ids[i];
            }
        }
    };

    return {
        deserializeCircularReferences: deserializeCircularReferences
    };
});