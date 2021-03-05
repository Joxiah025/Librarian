// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let bookId = null;

function deSelectCheckBoxes(param) {
    $(".custom-checkbox").each(function (e) {
        if (this != param) {
            $(this).prop("checked", false);
        }
    });
}

$(".custom-checkbox").on("change", function (e) {
    e.preventDefault();
    const status = $(this).data("status");
    if ($(this).is(':checked')) {
        bookId = $(this).data("entityid");

        if (status == "CheckIn") {
            $(".checkOut").prop('disabled', false);
            $(".checkIn").prop('disabled', true);
        } else {
            $(".checkOut").prop('disabled', true);
            $(".checkIn").prop('disabled', false);
        }
    } else {
        bookId = null;
        $(".checkOut").prop('disabled', false);
        $(".checkIn").prop('disabled', false);
    }
    deSelectCheckBoxes(this);  
    
});

$(".checkIn").on("click", function (e) {
    if (!bookId) { alert("Select a book"); return; }

    window.location.replace("/Book/CheckIn/" + bookId);
});

$(".checkOut").on("click", function (e) {
    if (!bookId) { alert("Select a book"); return; }
    window.location.replace("/Book/CheckOut/" + bookId);
});

$(".details").on("click", function (e) {
    if (!bookId) { alert("Select a book"); return; }
    let btn = $(this);

    btn.prop('disabled', true).html('Please wait ...');
    $.ajax({
        url: '/Book/Details/' + bookId,
        method: 'GET',
        success: function (res) {
            console.log(res);
            let details = `<div class="d-flex justify-content-between">
                    <div class="">Book Title</div>
                    <div class="">${res.bookTitle}</div>
                </div>
                <div class="d-flex justify-content-between">
                    <div class="">ISBN</div>
                    <div class="">${res.isbn}</div>
                </div>
                <div class="d-flex justify-content-between">
                    <div class="">Published Year</div>
                    <div class="">${res.publishedYear}</div>
                </div>
                <div class="d-flex justify-content-between">
                    <div class="">Cover Price</div>
                    <div class="">${res.coverPrice}</div>
                </div>
                <div class="d-flex justify-content-between">
                    <div class="">Check in / Check out status</div>
                    <div class="">${ res.status == 0 ? "Checked In" : "Checked Out"}</div>
                </div>`;
                if (res.status == 1) {
                    details += `<div class="d-flex justify-content-between">
                        <div class="">Current Borrower</div>
                        <div class="">${ (res.bookDetail.length > 0) ? res.bookDetail[res.bookDetail.length - 1]['borrowerName'] : ""}</div>
                    </div>`;
                }

            details += `<h6 class="mt-4" > Check History</h6>
                <div class="mb-4">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Check Out Date</th>
                                <th>Check In Date</th>
                            </tr>
                        </thead>
                        <tbody>`;
            res.bookDetail.forEach(function (item) {
                details += `<tr>
                                <td>${item.borrowerName}</td>
                                <td>${(item.checkOutDate) ? new Date(item.checkOutDate).toLocaleDateString("en-NG") : "NA"}</td>
                                <td>${(item.actualReturnDate) ? new Date(item.actualReturnDate).toLocaleDateString("en-NG"): "NA"}</td>
                           </tr>`;
            });
            details += `</tbody>
                    </table>
                </div>`;
            $(".modal-body").html(details);
            $('#exampleModal').modal('show');
            btn.prop('disabled', false).html('Details');
        },
        error: function (err) {
            console.log(err);
            btn.prop('disabled', false).html('Details');
        }
    })
});


$(".saveCheckIn").on("click", function (e) {
    e.preventDefault();
    const id = $(this).data("id");
    const fined = $(this).data("fined");
    const bookId = $(this).data("bookid");
    let btn = $(this);

    btn.prop('disabled', true).html('Please wait ...');
    $.ajax({
        url: "/Book/CheckIn/" + bookId,
        method: "POST",
        data: { BookDetailId: id, Fine: fined, BookId: bookId },
        success: function (resp) {
            window.location.replace("/Book/Index/?CheckIn=true");
        },
        error: function (err) {
            console.log(err);
            btn.prop('disabled', false).html('Check In');
        }
    })
});