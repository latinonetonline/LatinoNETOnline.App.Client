namespace CanvasInterop {

    class CanvasInteropFunctions {


        public addPasteEventListener(canvas: HTMLCanvasElement, fileInput: HTMLInputElement, dotNetObject) {

            function retrieveImageFromClipboardAsBlob(pasteEvent: ClipboardEvent, callback: Function) {
                if (!pasteEvent.clipboardData) {
                    if (callback instanceof Function) {
                        callback(undefined, canvas);
                    }
                };

                const items: DataTransferItemList = pasteEvent.clipboardData.items;

                if (items == undefined) {
                    if (callback instanceof Function) {
                        callback(undefined, canvas)
                    }
                };

                for (var i = 0; i < items.length; i++) {

                    const entry: DataTransferItem = items[i];

                    if (entry.type.indexOf("image") == -1) continue;
                    // Retrieve image on clipboard as blob
                    let blob: File = entry.getAsFile();

                    if (callback instanceof Function) {
                        callback(blob, canvas);
                    }
                }
            }

            window.addEventListener("paste", function (e: ClipboardEvent) {

                // Handle the event
                retrieveImageFromClipboardAsBlob(e, function (imageBlob, canvas: HTMLCanvasElement) {
                    // If there's an image, display it in the canvas
                    if (imageBlob) {

                        const ctx: CanvasRenderingContext2D = canvas.getContext('2d');

                        // Create an image to render the blob on the canvas
                        var img = new Image();

                        // Once the image loads, render the img on the canvas
                        img.onload = function () {
                            // Update dimensions of the canvas with the dimensions of the image
                            canvas.width = (this as HTMLImageElement).width;
                            canvas.height = (this as HTMLImageElement).height;

                            // Draw the image
                            ctx.drawImage(img, 0, 0);
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
        }

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

        public getCanvasBase64(canvas: HTMLCanvasElement): string {

            var dataURL: string = canvas.toDataURL();
            return dataURL.split(',')[1];
        }

        public setBase64IntoCanvas(canvas: HTMLCanvasElement, imageBase64: string, dotNetObject): void {

            var ctx: CanvasRenderingContext2D = canvas.getContext("2d");

            var image = new Image();
            image.onload = function () {
                canvas.width = (this as HTMLImageElement).width;
                canvas.height = (this as HTMLImageElement).height;

                // Draw the image
                ctx.drawImage(image, 0, 0);
                dotNetObject.invokeMethodAsync('CanvasOnload');
            };
            image.src = imageBase64;
        }
    }

    export function Load(): void {
        window['CanvasInteropFunctions'] = new CanvasInteropFunctions();
    }
}

CanvasInterop.Load();