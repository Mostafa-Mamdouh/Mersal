export class accountChartTreeList
{
    id:number;
    name:string;
    code:string;
    parentAccountChartId:number;
    childs:accountChartTreeList[];
    accountLevel:number;
    IsFinalNode:boolean;
    isCreditAccount: boolean;
}