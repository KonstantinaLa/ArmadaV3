//Admiral
function CreateAdmiralTable() {
    $("#TabContent").html(`
                                             <h2 class="m-4 text-center">Admirals</h2>
                                            <table class="table table-hover table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Photo</th>
                                                        <th>Name</th>
                                                        <th>Age</th>
                                                        <th>Crew</th>
                                                        <th>Missions</th>
                                                        <th>Actions</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="admiralsBody">
                                            </tbody>
                                         </table>
                                       <button id="create" onclick="" class="btn btn-primary m-1">Create New</button>
                                        `);
}

$("#admiralTablebtn").click(function () {
    $.ajax({
        type: "GET",
        url: "/api/Admiral",
        data: "",
        dataType: "json",
        success: function (response) {
            CreateAdmiralTable();
            response.forEach(function (admiral) {
                $("#admiralsBody").append(`
                                                             <tr id = "adm${admiral.AdmiralId}">
                                                                 <td>
                                                                     ${admiral.Photo}
                                                                 </td>
                                                                 <td>
                                                                     ${admiral.Name}
                                                                 </td>
                                                                 <td>
                                                                     ${admiral.Age}
                                                                 </td>
                                                                 <td>
                                                                     ${admiral.Crew}
                                                                 </td>
                                                                 <td>
                                                                    <ul class="list-unstyled">
                                                                         ${admiral.Missions
                        .map(am => `<li> <strong>Mission ${am.MissionId}</strong> </br> <hr/>
                                                                                                      <strong>Type:</strong> ${am.Type} </br>
                                                                                                      <strong>Date:</strong> ${am.StartDate} </br>
                                                                                                      <strong>Is Success:</strong>${am.IsSuccess} </br><hr/>
                                                                                                  </li>`).join(' ')}
                                                                    </ul>
                                                                 </td>
                                                                 <td>
                                                                     <button id="info" onclick="ShowAdmiralInfoModal(${admiral.AdmiralId})" class="btn btn-info btn-sm">Info</button>
                                                                     <button id="edit" onclick="" class="btn btn-primary btn-sm">Edit</button>
                                                                     <button id="delete" onclick="ShowAdmiralDeleteModal(${admiral.AdmiralId})" class="btn btn-danger btn-sm">Delete</button>
                                                                 </td>
                                                             </tr>
                                                            `);
            });
        }
    });

});

function ShowAdmiralInfoModal(id) {
    $.ajax({
        type: "GET",
        url: `/api/Admiral/?id=${id}`,
        data: "",
        dataType: "json",
        success: function (response) {
            $(document).ready(function () {
                $("#ArmadaModal").modal();
            });

            $("#modalBody").html(`<ul>
                                                     <li> <p class ="text-info"> <strong>Serving Empire:</strong> ${response.Empire} </p> </li>
                                                     <li> <p class ="text-info"> <strong>Enlistment Date:</strong> ${response.EnlistmentDate} </p> </li>
                                                     <li> <p class ="text-info"> <strong>About:</strong> ${response
                    .Description} </p> </li>
                                                    <ul>`);

            $("#modalFooter")
                .html(
                    '<button type="button" class="btn btn-secondary close" data-bs-dismiss="modal">Cancel</button>');

            $(".close").click(function () {
                $("#ArmadaModal").modal("hide");
            });
        }
    });
}

function ShowAdmiralDeleteModal(id) {
    $(document).ready(function () {
        $("#ArmadaModal").modal();
    });

    $("#modalBody").html('<p class="text-danger"><strong>Are you sure you want to delete this?</strong></p>');

    $("#modalFooter").html(
        `
                                        <button type="button" onclick="DeleteAdmiral(${id
        })" class="btn btn-danger deletebtn">Delete</button>
                                        <button type="button" class="btn btn-secondary close" data-bs-dismiss="modal">Cancel</button>
                                        `
    );

    $(".close").click(function () {
        $("#ArmadaModal").modal("hide");
    });
}

function DeleteAdmiral(id) {
    $.ajax({
        type: "DELETE",
        url: `/api/Admiral/?id=${id}`,
        data: "",
        dataType: "json",
        success: function (response) {
            setTimeout(() => $("#deleteAlert").html(`
                                                        <div class="alert alert-dismissible alert-warning">
                                                          <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                                                          <h4 class="alert-heading">Successfully deleted</h4>
                                                          <p class="mb-0">${response.Name}</p>
                                                        </div>
                                                    `).fadeOut(4000),
                500);
        }
    });
    $("#ArmadaModal").modal("hide");
    $(`#adm${id}`).remove();
}