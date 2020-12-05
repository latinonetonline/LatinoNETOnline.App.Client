namespace Input {

    class InputFunction {
        public GetText(input: HTMLTextAreaElement): string {
            return input.value;
        }

        public SetKeyUpDelegate(input: HTMLTextAreaElement, dotNetObject): void {
            input.onkeyup = function () {
                dotNetObject.invokeMethodAsync('InputOnKeyUp');
            }
        }
    }

    export function Load(): void {
        window['InputFunction'] = new InputFunction();
    }
}

Input.Load();