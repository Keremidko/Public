RDE.factory('Item', function ($http, ItemType) {
    var createContents = function (type) {
        switch (type)
        {
            case ItemType["Document"]: {
                return null;
                break;
            }
            case ItemType["Diagram"]: {
                return JSON.stringify({
                    widgets: []
                })
                break;
            }
            default: break;
        }
    }

    var Item = function (params) {
        this.ID = -1;
        this.ProjectID = -1;
        this.ParentID = params.parentId;
        this.Name = params.name;
        this.Type = params.type;
        this.Contents = createContents(params.type);
    };

    var ClassDiagram = function (x, y) {
        this.type = "class";
        this.title = "Title";
        this.position = { x: x, y: y };
        this.properties = [""];
        this.methods = [""];
    };

    var Text = function (x,y) {
        this.type = "text";
        this.position = { x: x, y: y };
        this.data = "";
    }

    var Comment = function (x, y) {
        this.type = "comment";
        this.position = { x: x, y: y };
        this.text = "Insert text here!";
    };

    var Line = function (x, y) {
        this.type = "line";
        this.position = { x: x, y: y };
        this.points = [];
        this.points.push({ x: x, y: y });
        this.startPoint = '#markerCircle';
        this.endPoint = '#markerArrow';
        this.addPoint = function (point) {
            if (this.position.x < point.x)
                this.position.x = point.x;
            if (this.position.y < point.y)
                this.position.y = point.y;
            this.points.push(point);
        };
    };

    var Ellipse = function (x,y) {
        this.type = "ellipse";
        this.position = {
            x: x,
            y: y,
            translateX : 0,
            translateY: 0,
            sX: 1,
            sY :1
        };
        this.rx = 40;
        this.ry = 20;
    };

    var Rectangle = function (x, y) {
        this.type = "rectangle";
        this.position = {
            x: x,
            y: y,
            translateX: 0,
            translateY: 0,
            sX: 1,
            sY: 1
        };
        this.rx = 10;
    }

    return {
        createItem: function (params, projectId, templateId) {
            var item = new Item(params);
            return $http({
                method: "POST",
                url: "/api/Item/CreateItem",
                data: item,
                params: {
                    projectId: projectId,
                    templateId: templateId
                }
            });
        },
        createRectangle : function(x, y) {
            return new Rectangle(x, y);
        },
        createEllipse : function(x, y)  {
            return new Ellipse(x, y);
        },
        createText : function(x, y) {
            return new Text(x, y);
        },
        createClassDiagram: function (x, y) {
            return new ClassDiagram(x, y);
        },
        createComment: function (x, y) {
            return new Comment(x, y);
        },
        createLine: function (x, y) {
            return new Line(x, y);
        }
    };
});

RDE.factory('ItemType', function () {
    return {
        "Folder": 1,
        "Document": 2,
        "Diagram" : 3
    };
});

RDE.factory('ItemInProcess', function () {
    var ItemInProcess = function (itemReference, dirty) {
        this.ref = itemReference;
        this.dirtyContent = angular.copy(itemReference.Contents);
        this.isDirty = function () {
            if (this.ref.Contents == null && this.dirtyContent == "")
                return false;
            return this.dirtyContent != this.ref.Contents;
        }
    }

    return ItemInProcess;
});