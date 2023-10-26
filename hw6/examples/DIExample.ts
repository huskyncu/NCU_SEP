import { GearMechanism } from "./GearMechanism";

export class DIExampleClock {
    private name: string;

    private gearMechanism: GearMechanism;

    // 使用 Constructor Injection
    constructor(name: string, gear: GearMechanism) {
        this.name = name;
        this.gearMechanism = gear
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