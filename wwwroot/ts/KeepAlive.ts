namespace KeepAlive {

    class KeepAliveFunction {
        private interval: number = 0;

        public startAlive(): void {
            this.interval = setInterval(() => {
                fetch("/health")
            }, 10 * 60000);

        }

        public getInterval() {
            return this.interval;
        }
    }

    export function Load(): void {

        const functions = new KeepAliveFunction();
        window['KeepAliveFunction'] = functions;

        functions.startAlive();
    }
}

KeepAlive.Load();