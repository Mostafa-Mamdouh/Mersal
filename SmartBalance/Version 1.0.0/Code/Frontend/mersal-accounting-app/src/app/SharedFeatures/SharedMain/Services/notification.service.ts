import { Injectable } from '@angular/core';
import { ToastrService} from 'ngx-toastr';
import { TranslateService} from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(
    private toastrService: ToastrService,
    private translateService: TranslateService
  ) { }

  showSuccess(message?: string, title?: string, override?: any) {
    this.toastrService.success(message, title, override);
  }

  showSuccessHtml(message?: string, title?: string) {
    this.toastrService.success(message, title, {
      enableHtml:true,
      closeButton: true
    });
  }

  showInfo(message?: string, title?: string, override?: any) {
    this.toastrService.info(message, title, override);
  }
  showInfoHtml(message?: string, title?: string) {
    this.toastrService.info(message, title, {
      enableHtml:true,
      closeButton: true
    });
  }
  showTranslateError(msg?: string) {
    this.translateService.get(msg).subscribe(val =>this.showError(val));
  }

  showTranslateSuccess(msg?: string,title? :string) {
    this.translateService.get(msg).subscribe(val =>this.showSuccess(title,val));
  }

  showError(message?: string, title?: string, override?: any) {
    this.toastrService.error(message, title, override);
  }
  showErrorHtml(message?: string, title?: string) {
    this.toastrService.error(message, title, {
      enableHtml:true,
      closeButton: true
    });
  }

  showWarning(message?: string, title?: string, override?: any) {
    this.toastrService.warning(message, title, override);
  }
  showWarningHtml(message?: string, title?: string) {
    this.toastrService.warning(message, title, {
      enableHtml:true,
      closeButton: true
    });
  }

  showOperationSuccessed() {
    this.translateService.get(['shared.operationSuccessed'])
    .subscribe(res => {
      this.showSuccess(res['shared.operationSuccessed']);
    });
  }

  showEffiencyRaiseSuccessed() {
    this.translateService.get(['asset.shared.EffiencyRaiseSuccessed'])
    .subscribe(res => {
      this.showSuccess(res['asset.shared.EffiencyRaiseSuccessed']);
    });
  }

  EffiencyRaiseSuccessed

  showOperationFailed() {
    this.translateService.get(['shared.operationFailed'])
    .subscribe(res => {
      this.showError(res['shared.operationFailed']);
    });
  }




  showUnderDevelopmentInfo() {
    this.translateService.get(['shared.underDevelopment'])
    .subscribe(res => {
      this.showInfoHtml(`<h3>${res['shared.underDevelopment']}</h3>`, '');
    });
  }



  /**
   * show success message with document id 
   * */
  showSuccessAlertForSavedDocument(documentId: any) {
    let keyAddedSuccessfully = 'shared.addedSuccessfully';
    let keyDonationCode = 'donation.code';
    //let keyDonationCode = 'purchasing.shared.code';
    this.translateService.get([keyAddedSuccessfully, keyDonationCode]).subscribe(res => {
      this.showSuccessHtml(`<h3>${res[keyAddedSuccessfully]}</h3><h4>${res[keyDonationCode]}</h4><h4>${documentId}</h4>`, '');
    });
  }
  showJournalcanceled() {
    let keyJournalcanceled = 'journalEntries.post.journalcanceled';
    //let keyDonationCode = 'purchasing.shared.code';
    this.translateService.get([keyJournalcanceled]).subscribe(res => {
      this.showInfoHtml(`<h3>${res[keyJournalcanceled]}</h3>`, '');
    });
  }

  showDataMissingError() {
    let keyDataMissing = 'error.dataMissing';
    this.translateService.get([keyDataMissing]).subscribe(res => {
      this.showErrorHtml(`<h4>${res[keyDataMissing]}</h4>`, '');
    });
  }

  showPaymentDirectionError() {
    let PaymentDirectionError = 'financial.PaymentDirectionError';
    this.translateService.get([PaymentDirectionError]).subscribe(res => {
      this.showErrorHtml(`<h4>${res[PaymentDirectionError]}</h4>`, '');
    });
  }


  showPaymentError() {
    let PaymentError = 'financial.PaymentError';
    this.translateService.get([PaymentError]).subscribe(res => {
      this.showErrorHtml(`<h4>${res[PaymentError]}</h4>`, '');
    });
  }

  showAuthError() {
    let key = 'error.auth';
    this.translateService.get([key]).subscribe(res => {
      this.showErrorHtml(`<h5>${res[key]}</h5>`, '');
    });
  }
  showTranslateHtmlError_h5(msg?: string) {
    let errorKey = msg;
    this.translateService.get([errorKey])
      .subscribe(res => {
        this.showErrorHtml(`<h5>${res[errorKey]}</h5>`);
      });   
  }
  showTranslateHtmlInfo_h5(msg?: string) {
    let key = msg;
    this.translateService.get([key])
      .subscribe(res => {
        this.showInfoHtml(`<h5>${res[key]}</h5>`);
      });   
  }


  showOperationFailedToLoadVendors() {
    this.translateService.get(['shared.loadVendorsFailed'])
    .subscribe(res => {
      this.showError(res['shared.loadVendorsFailed']);
    });
  }
}
