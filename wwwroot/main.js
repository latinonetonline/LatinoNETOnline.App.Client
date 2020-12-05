var BzCopyBoard;
(function (BzCopyBoard) {
    var BzCopyBoardFunction = /** @class */ (function () {
        function BzCopyBoardFunction() {
        }
        BzCopyBoardFunction.prototype.CopyText = function (text) {
            window.navigator.clipboard.writeText(text).then(function () {
                console.info("Copied to clipboard!");
            })
                .catch(function (error) {
                console.error(error);
            });
        };
        return BzCopyBoardFunction;
    }());
    function Load() {
        window['BzCopyBoardFunction'] = new BzCopyBoardFunction();
    }
    BzCopyBoard.Load = Load;
})(BzCopyBoard || (BzCopyBoard = {}));
BzCopyBoard.Load();
var CanvasInterop;
(function (CanvasInterop) {
    var CanvasInteropFunctions = /** @class */ (function () {
        function CanvasInteropFunctions() {
        }
        CanvasInteropFunctions.prototype.addPasteEventListener = function (canvas, fileInput, dotNetObject) {
            function retrieveImageFromClipboardAsBlob(pasteEvent, callback) {
                if (!pasteEvent.clipboardData) {
                    if (callback instanceof Function) {
                        callback(undefined, canvas);
                    }
                }
                ;
                var items = pasteEvent.clipboardData.items;
                if (items == undefined) {
                    if (callback instanceof Function) {
                        callback(undefined, canvas);
                    }
                }
                ;
                for (var i = 0; i < items.length; i++) {
                    var entry = items[i];
                    if (entry.type.indexOf("image") == -1)
                        continue;
                    // Retrieve image on clipboard as blob
                    var blob = entry.getAsFile();
                    if (callback instanceof Function) {
                        callback(blob, canvas);
                    }
                }
            }
            window.addEventListener("paste", function (e) {
                // Handle the event
                retrieveImageFromClipboardAsBlob(e, function (imageBlob, canvas) {
                    // If there's an image, display it in the canvas
                    if (imageBlob) {
                        var ctx_1 = canvas.getContext('2d');
                        // Create an image to render the blob on the canvas
                        var img = new Image();
                        // Once the image loads, render the img on the canvas
                        img.onload = function () {
                            // Update dimensions of the canvas with the dimensions of the image
                            canvas.width = this.width;
                            canvas.height = this.height;
                            // Draw the image
                            ctx_1.drawImage(img, 0, 0);
                            dotNetObject.invokeMethodAsync('CanvasOnload');
                        };
                        // Crossbrowser support for URL
                        var URLObj = window.URL || window.webkitURL;
                        // Creates a DOMString containing a URL representing the object given in the parameter
                        // namely the original Blob
                        img.src = URLObj.createObjectURL(imageBlob);
                        fileInput.value = null;
                    }
                });
            }, false);
        };
        //public retrieveImageFromClipboardAsBlob(pasteEvent: ClipboardEvent, callback: Function) {
        //    if (!pasteEvent.clipboardData) {
        //        if (typeof (callback) == "function") {
        //            callback(undefined);
        //        }
        //    };
        //    var items = pasteEvent.clipboardData.items;
        //    if (items == undefined) {
        //        if (typeof (callback) == "function") {
        //            callback(undefined);
        //        }
        //    };
        //    for (var i = 0; i < items.length; i++) {
        //        // Skip content if not image
        //        if (items[i].type.indexOf("image") == -1) continue;
        //        // Retrieve image on clipboard as blob
        //        var blob = items[i].getAsFile();
        //        if (typeof (callback) == "function") {
        //            callback(blob);
        //        }
        //    }
        //}
        CanvasInteropFunctions.prototype.getCanvasBase64 = function (canvas) {
            var dataURL = canvas.toDataURL();
            return dataURL.split(',')[1];
        };
        CanvasInteropFunctions.prototype.setBase64IntoCanvas = function (canvas, imageBase64, dotNetObject) {
            var ctx = canvas.getContext("2d");
            var image = new Image();
            image.onload = function () {
                canvas.width = this.width;
                canvas.height = this.height;
                // Draw the image
                ctx.drawImage(image, 0, 0);
                dotNetObject.invokeMethodAsync('CanvasOnload');
            };
            image.src = imageBase64;
        };
        return CanvasInteropFunctions;
    }());
    function Load() {
        window['CanvasInteropFunctions'] = new CanvasInteropFunctions();
    }
    CanvasInterop.Load = Load;
})(CanvasInterop || (CanvasInterop = {}));
CanvasInterop.Load();
var Input;
(function (Input) {
    var InputFunction = /** @class */ (function () {
        function InputFunction() {
        }
        InputFunction.prototype.GetText = function (input) {
            return input.value;
        };
        InputFunction.prototype.SetKeyUpDelegate = function (input, dotNetObject) {
            input.onkeyup = function () {
                dotNetObject.invokeMethodAsync('InputOnKeyUp');
            };
        };
        return InputFunction;
    }());
    function Load() {
        window['InputFunction'] = new InputFunction();
    }
    Input.Load = Load;
})(Input || (Input = {}));
Input.Load();
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
//# sourceMappingURL=main.js.map