//Planet
function CreatePlanetTable() {
    $("#TabContent").html(`
                                             <h2 class="m-4 text-center">Planets</h2>
                                            <table class="table table-hover table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Name</th>
                                                        <th>Star System</th>
                                                        <th>Missions</th>
                                                        <th>Actions</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="planetsBody">
                                            </tbody>
                                         </table>
                                       <button id="create" onclick="" class="btn btn-primary m-1">Create New</button>
                                        `);
}

$("#planetTablebtn").click(function () {
    $.ajax({
        type: "GET",
        url: "/api/Planet",
        data: "",
        dataType: "json",
        success: function (response) {
            CreatePlanetTable();
            response.forEach(function (planet) {
                $("#planetsBody").append(`
                                                              <tr id = pl${planet.PlanetId}>
                                                                 <td>
                                                                     ${planet.Name}
                                                                 </td>
                                                                 <td>
                                                                     ${planet.StarSystem}
                                                                 </td>
                                                                 <td>
                                                                    <ul class = "list-unstyled">
                                                                     ${ShowPlanetMissions(planet)}
                                                                    </ul>
                                                                 </td>
                                                                 <td>
                                                                     <button id="info" onclick="ShowPlanetInfoModal(${planet.PlanetId})" class="btn btn-info btn-sm">Info</button>
                                                                     <button id="edit" onclick="" class="btn btn-primary btn-sm">Edit</button>
                                                                     <button id="delete" onclick="ShowPlanetDeleteModal(${planet.PlanetId})" class="btn btn-danger btn-sm">Delete</button>
                                                                 </td>
                                                             </tr>
                                                            `);
            });

        }
    });

});

function ShowPlanetMissions(planet) {
    let template = "";
    for (var mission of planet.Missions) {
        template += `<li>
                                        ${mission.Type}
                                        </li>`;
    }

    return template;
}

function ShowPlanetInfoModal(id) {
    $.ajax({
        type: "GET",
        url: `/api/Planet/?id=${id}`,
        data: "",
        dataType: "json",
        success: function (response) {
            $(document).ready(function () {
                $("#ArmadaModal").modal();
            });

            $("#modalBody").html(`<ul>
                                                     <li> <p class ="text-info"> <strong>Name:</strong> ${response.Name
                } </p> </li>
                                                     <li> <p class ="text-info"> <strong>Planet Type:</strong> ${response.Type} </p> </li>
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

function ShowPlanetDeleteModal(id) {
    $(document).ready(function () {
        $("#ArmadaModal").modal();
    });

    $("#modalBody").html('<p class="text-danger"><strong>Are you sure you want to delete this?</strong></p>');

    $("#modalFooter").html(
        `
                                        <button type="button" onclick="DeletePlanet(${id
        })" class="btn btn-danger deletebtn">Delete</button>
                                        <button type="button" class="btn btn-secondary close" data-bs-dismiss="modal">Cancel</button>
                                        `
    );

    $(".close").click(function () {
        $("#ArmadaModal").modal("hide");
    });
}

function DeletePlanet(id) {
    $.ajax({
        type: "DELETE",
        url: `/api/Planet/?id=${id}`,
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
    $(`#pl${id}`).remove();
}
