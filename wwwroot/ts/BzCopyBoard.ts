namespace BzCopyBoard {

    class BzCopyBoardFunction {
        public CopyText(text: string): void {

                window.navigator.clipboard.writeText(text).then(function () {
                    console.info("Copied to clipboard!");
                })
                .catch(function (error) {
                    console.error(error);
                });

        }
    }

    export function Load(): void {
        window['BzCopyBoardFunction'] = new BzCopyBoardFunction();
    }
}

BzCopyBoard.Load();