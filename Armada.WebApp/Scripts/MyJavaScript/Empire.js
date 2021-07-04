
//Empire
function CreateEmpireTable() {
    $("#TabContent").html(`
                                          <h2 class="m-4 text-center">Empires</h2>
                                            <table class="table table-hover table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Photo</th>
                                                        <th>Name</th>
                                                        <th>Trait</th>
                                                        <th>Controlled System</th>
                                                        <th>Admirals</th>
                                                        <th>Actions</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="empiresBody">
                                            </tbody>
                                         </table>
                                       <button id="create" onclick="" class="btn btn-primary m-1">Create New</button>
                                        `);
}

$("#empireTablebtn").click(function () {
    $.ajax({
        type: "GET",
        url: "/api/Empire",
        data: "",
        dataType: "json",
        success: function (response) {
            CreateEmpireTable();
            response.forEach(function (empire) {
                $("#empiresBody").append(`
                                                                 <tr id = "empire${empire.EmpireId}">
                                                                 <td>
                                                                     ${empire.Photo}
                                                                 </td>
                                                                 <td>
                                                                     ${empire.Name}
                                                                 </td>
                                                                 <td>
                                                                     ${empire.Trait}
                                                                 </td>
                                                                 <td>
                                                                     ${empire.ControlledSystem}
                                                                 </td>
                                                                 <td>
                                                                     <ul class="list-unstyled">
                                                                     ${ShowEmpireAdmirals(empire)}
                                                                     </ul>
                                                                 </td>
                                                                 <td>
                                                                     <button id="info" onclick="ShowEmpireInfoModal(${empire.EmpireId})" class="btn btn-info btn-sm">Info</button>
                                                                     <button id="edit" onclick="" class="btn btn-primary btn-sm">Edit</button>
                                                                     <button id="delete" onclick="ShowEmpireDeleteModal(${empire.EmpireId})" class="btn btn-danger btn-sm">Delete</button>
                                                                 </td>
                                                             </tr>
                                                            `);
            });
        }
    });

});

function ShowEmpireAdmirals(empire) {
    let template = "";
    for (var admiral of empire.Admirals) {
        template += `<li>
                                        ${admiral.Name}
                                             <strong>Species: </strong>
                                        ${admiral.Species}
                                        </li></br>`;
    }

    return template;
}

function ShowEmpireInfoModal(id) {
    $.ajax({
        type: "GET",
        url: `/api/Empire/?id=${id}`,
        data: "",
        dataType: "json",
        success: function (response) {
            $(document).ready(function () {
                $("#ArmadaModal").modal();
            });

            $("#modalBody").html(`<ul>
                                                     <li> <p class ="text-info"> <strong>Emperor ruling:</strong> ${response.Emperor} </p> </li>
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

function ShowEmpireDeleteModal(id) {
    $(document).ready(function () {
        $("#ArmadaModal").modal();
    });

    $("#modalBody").html('<p class="text-danger"><strong>Are you sure you want to delete this?</strong></p>');

    $("#modalFooter").html(
        `
                                        <button type="button" onclick="DeleteEmpire(${id
        })" class="btn btn-danger deletebtn">Delete</button>
                                        <button type="button" class="btn btn-secondary close" data-bs-dismiss="modal">Cancel</button>
                                        `
    );

    $(".close").click(function () {
        $("#ArmadaModal").modal("hide");
    });
}

function DeleteEmpire(id) {
    $.ajax({
        type: "DELETE",
        url: `/api/Empire/?id=${id}`,
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
    $(`#empire${id}`).remove();
}