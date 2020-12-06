var KeepAlive;
(function (KeepAlive) {
    var KeepAliveFunction = /** @class */ (function () {
        function KeepAliveFunction() {
            this.interval = 0;
        }
        KeepAliveFunction.prototype.startAlive = function () {
            this.interval = setInterval(function () {
                fetch("/health");
            }, 10 * 60000);
        };
        KeepAliveFunction.prototype.getInterval = function () {
            return this.interval;
        };
        return KeepAliveFunction;
    }());
    function Load() {
        var functions = new KeepAliveFunction();
        window['KeepAliveFunction'] = functions;
        functions.startAlive();
    }
    KeepAlive.Load = Load;
})(KeepAlive || (KeepAlive = {}));
KeepAlive.Load();
//# sourceMappingURL=KeepAlive.js.map