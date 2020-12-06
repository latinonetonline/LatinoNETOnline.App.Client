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
//# sourceMappingURL=InputInterop.js.map