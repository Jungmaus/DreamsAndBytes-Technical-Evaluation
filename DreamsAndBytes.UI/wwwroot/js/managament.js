
let addToBasket = (productId) => {
    $.ajax({
        url: "/Basket/AddProductToBasket?id=" + productId,
        method: "POST",
        success: () => {
            alert("İşleminiz başarıyla tamamlandı.");
            location.reload();
        },
        failure: () => {
            alert("Bir hata oluştu.");
        }
    });
};

let deletee = (productId) => {
    if (confirm('Bu ürünü silmek istediğinizden emin misiniz ?')) {
        $.ajax({
            url: "/Product/Delete?id=" + productId,
            method: "POST",
            success: () => {
                alert("Ürün başarıyla silindi.");
                location.reload();
            },
            failure: () => {
                alert("Bir hata oluştu.");
            }
        });
    }
};