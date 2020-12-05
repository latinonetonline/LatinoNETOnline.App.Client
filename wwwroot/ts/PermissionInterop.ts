namespace PermissionInterop {

    class PermissionInteropFunctions {

        public handlePermission() {
            navigator.permissions.query({ name: 'clipboard-write' as PermissionName }).then(function (result: PermissionStatus) {
                if (result.state == 'granted') {
                    console.log('Permission: ' + result.state);
                } else if (result.state == 'prompt') {
                    console.log('Permission: ' + result.state);
                } else if (result.state == 'denied') {
                    console.log('Permission: ' + result.state);
                }
                result.onchange = function () {
                    console.log('Permission: ' + result.state);
                }
            });
        }
    }

    export function Load(): void {

        const functions = new PermissionInteropFunctions();
        window['PermissionInteropFunctions'] = functions;

        functions.handlePermission();
    }
}

PermissionInterop.Load()