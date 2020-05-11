import { ModelStatus } from '../../Account-Document/Models/account-document.model';

export class AccountChart{
    id: number;
    displyedName: string;
    modelStatus: ModelStatus = ModelStatus.Unmodify;
}

export class FixedAssetAccountChart{
    id: number;
    value: string;
    accountChartViewModel: AccountChart;
}