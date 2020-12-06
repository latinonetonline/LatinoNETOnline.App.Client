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
//# sourceMappingURL=BzCopyBoard.js.map