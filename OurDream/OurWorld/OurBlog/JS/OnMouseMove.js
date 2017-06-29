﻿var Follow = function () {
    var $ = function (i) { return document.getElementById(i) },
    addEvent = function (o, e, f) { o.addEventListener ? o.addEventListener(e, f, false) : o.attachEvent('on' + e, function () { f.call(o) }) },
    OBJ = [], sp, rs, N = 0, m;
    var init = function (id, config) {
        this.config = config || {};
        this.obj = $(id);
        sp = this.config.speed || 4;
        rs = this.config.animR || 1;
        m = { x: $(id).offsetWidth * .5, y: $(id).offsetHeight * .5 };
        this.setXY();
        this.start();
    }
    init.prototype = {
        setXY: function () {
            var _this = this;
            addEvent(this.obj, 'mousemove', function (e) {
                e = e || window.event;
                m.x = e.clientX;
                m.y = e.clientY;
            })
        },
        start: function () {
            var k = 180 / Math.PI, OO, o, _this = this, fn = this.config.fn;
            OBJ[N++] = OO = new CObj(null, 0, 0);
            for (var i = 0; i < 360; i += 20) {
                var O = OO;
                for (var j = 10; j < 35; j += 1) {
                    var x = fn(i, j).x,
                    y = fn(i, j).y;
                    OBJ[N++] = o = new CObj(O, x, y);
                    O = o;
                }
            }
            setInterval(function () {
                for (var i = 0; i < N; i++) OBJ[i].run();
            }, 16);
        }
    }
    var CObj = function (p, cx, cy) {
        var obj = document.createElement("span");
        this.css = obj.style;
        this.css.position = "absolute";
        this.css.left = "-1000px";
        this.css.zIndex = 1000 - N;
        document.getElementById("screen").appendChild(obj);
        this.ddx = 0;
        this.ddy = 0;
        this.PX = 0;
        this.PY = 0;
        this.x = 0;
        this.y = 0;
        this.x0 = 0;
        this.y0 = 0;
        this.cx = cx;
        this.cy = cy;
        this.parent = p;
    }
    CObj.prototype.run = function () {
        if (!this.parent) {
            this.x0 = m.x;
            this.y0 = m.y;
        } else {
            this.x0 = this.parent.x;
            this.y0 = this.parent.y;
        }
        this.x = this.PX += (this.ddx += ((this.x0 - this.PX - this.ddx) + this.cx) / rs) / sp;
        this.y = this.PY += (this.ddy += ((this.y0 - this.PY - this.ddy) + this.cy) / rs) / sp;
        this.css.left = Math.round(this.x) + 'px';
        this.css.top = Math.round(this.y) + 'px';
    }
    return init;
}();