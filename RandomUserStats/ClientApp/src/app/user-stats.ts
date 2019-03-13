export class UserStats {
    femaleToMaleRatio: number;
    aThroughMFirstNameRatio: number;
    aThroughMLastNameRatio: number;
    mostPopulousStates: StatePopulationPercentage[];
    ageRangePercentages: AgeRangePercentages;
}

export class StatePopulationPercentage {
    state: string;
    percentageOfTotalPopulation: number;
    femalePercent: number;
    malePercent: number;
}

export class AgeRangePercentages {
    zeroThroughTwenty: number;
    twentyOneThroughForty: number;
    fortyOneThroughSixty: number;
    sixtyOneThroughEighty: number;
    eightyOneThroughOneHundred: number;
    overOneHundred: number;
}
