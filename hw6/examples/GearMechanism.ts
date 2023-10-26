export class GearMechanism {
    private timestamp: number;

    private passTime: number;

    constructor() {
        console.log("Real GearMechanism is Constructed");
        this.timestamp = Date.now();
    }

    public run() {
        this.passTime += Math.random() + 1;
        this.adjust();
    }

    public reset() {
        this.passTime = 0;
    }

    private adjust() {
        this.passTime -= Math.random();
    }

    public getPassTime() {
        return this.passTime;
    }

    public setTimestamp(timestamp: number) {
        this.timestamp = timestamp;
    }
}
