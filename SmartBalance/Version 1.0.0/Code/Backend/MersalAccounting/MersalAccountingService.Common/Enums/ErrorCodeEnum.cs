namespace MersalAccountingService.Common.Enums
{
    public enum ErrorCodeEnum
    {
        InvalidAccountLevel = 1,
        ParentAccountNotExist = 2,
        CodeAlreadyExist = 3,
        ParentAccountNotIsSubAccount = 4,
        EmailAlreadyExist = 5,
        PhoneAlreadyExist = 6,
        NotPurchaseInvoiceOrRebate = 7,
        UserNameAlreadyExist = 8,
        CurrentUserCannotDiactivateHimself = 9,
        CurrentUserCannotChangeHisPermissions = 10,
        CurrentUserCannotChangeHisRoles = 11,
        CurrentUserCannotChangeHisGroups = 12,
        CurrentUserCannotChangeHisMenuItems = 13,
        AccountCurrencyMismatch = 14,
        LocationNotExist = 15,
        NoInventoryExist = 16,
        PasswordIncorrect = 17,
        JournalNotbalanced = 18,
        DocomentNumberAlreadyExist = 19,
        InvalidDonatorExcelSheet = 20,
        FromDateMustBeTheFirstDayInMonth = 21,
        ToDateMustBeTheLastDayInMonth = 22,
        FromMonthAndToMonthAreNotTheSame = 23,
        ThisMonthHasBeenAddedBefore = 24,
        ThisMonthIsClosed = 25,
        ThisReceiptNumberClosed = 26,
        NoFixedAssetAccountChartExist = 27,
        ThisReceiptNumberOutOfRange = 28,
        ThisBankDonotHaveAccountChart = 29,
        DiscountPercentageAlreadyExist = 30
    }
}
