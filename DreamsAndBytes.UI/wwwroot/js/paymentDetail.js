
let paymentTypeElement = $("#PaymentType");

paymentTypeElement.change(() => {

    hideAllPaymentTypeDivs();

    switch (paymentTypeElement.val()) {
        case "1":
            $("#CreditCard").show(500);
            break;
        case "2":
            $("#Kiss").show(500);
            break;
    }

});


let hideAllPaymentTypeDivs = () => {

    $("#CreditCard").hide();
    $("#Kiss").hide();

}