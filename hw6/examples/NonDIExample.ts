import { GearMechanism } from "./GearMechanism";

export class NonDIExampleClock {
    private name: string;

    private gearMechanism: GearMechanism;

    // 沒有使用 Constructor Injection
    constructor(name: string) {
        this.name = name;
        this.gearMechanism = new GearMechanism();
    }

    public tick() {
        this.gearMechanism.run();
        if (this.gearMechanism.getPassTime() < 0) {
            this.gearMechanism.reset();
        }
    }

    public reset() {
        this.gearMechanism.reset();
    }

    public getTime() {
        const time = this.gearMechanism.getPassTime();
        if (time < 0) {
            return 0;
        }
        return time;
    }

    public getName() {
        return this.name;
    }
}