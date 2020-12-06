var PermissionInterop;
(function (PermissionInterop) {
    var PermissionInteropFunctions = /** @class */ (function () {
        function PermissionInteropFunctions() {
        }
        PermissionInteropFunctions.prototype.handlePermission = function () {
            navigator.permissions.query({ name: 'clipboard-write' }).then(function (result) {
                if (result.state == 'granted') {
                    console.log('Permission: ' + result.state);
                }
                else if (result.state == 'prompt') {
                    console.log('Permission: ' + result.state);
                }
                else if (result.state == 'denied') {
                    console.log('Permission: ' + result.state);
                }
                result.onchange = function () {
                    console.log('Permission: ' + result.state);
                };
            });
        };
        return PermissionInteropFunctions;
    }());
    function Load() {
        var functions = new PermissionInteropFunctions();
        window['PermissionInteropFunctions'] = functions;
        functions.handlePermission();
    }
    PermissionInterop.Load = Load;
})(PermissionInterop || (PermissionInterop = {}));
PermissionInterop.Load();
//# sourceMappingURL=PermissionInterop.js.map