export interface EpochTime {
    hour: number;
    day: number;
    week: number;    
}

export class SpyOnExample {
    constructor() {

    }

    public getThisYearTimePassed() {
        // Date.parse("2023-01-01 00:00:00") = 1672502400000 
        const date = Math.floor((Date.now() - Date.parse("2023-01-01 00:00:00")) / 1000);
        const obj: EpochTime = {
            hour: Math.floor(date / (60 * 60)),
            day:  Math.floor(date / (60 * 60 * 24)),
            week: Math.floor(date / (60 * 60 * 24 * 7))
        }
        return obj;
    }
}