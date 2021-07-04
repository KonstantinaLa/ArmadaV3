//Mission
function CreateMissionTable() {
    $("#TabContent").html(`
                                            <h2 class="m-4 text-center">Missions</h2>
                                            <table class="table table-hover table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Type</th>
                                                        <th>Duration</th>
                                                        <th>Planets</th>
                                                        <th>Admirals</th>
                                                        <th>Actions</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="missionsBody">
                                            </tbody>
                                         </table>
                                        <button id="create" onclick="" class="btn btn-primary m-1">Create New</button>
                                        `);
}

$("#missionTablebtn").click(function () {
    $.ajax({
        type: "GET",
        url: "/api/Mission",
        data: "",
        dataType: "json",
        success: function (response) {
            CreateMissionTable();
            response.forEach(function (mission) {
                $("#missionsBody").append(`
                                                            <tr id = miss${mission.MissionId}>
                                                                 <td>
                                                                     ${mission.Type}
                                                                 </td>
                                                                 <td>
                                                                     ${mission.Duration}
                                                                 </td>
                                                                 <td>
                                                                     <ul class = "list-unstyled">
                                                                        ${ShowMissionPlanets(mission)}
                                                                    </ul>
                                                                 </td>
                                                                 <td>
                                                                     <ul class = "list-unstyled">
                                                                        ${ShowMissionAdmirals(mission)}
                                                                    </ul>
                                                                 </td>
                                                                 <td>
                                                                     <button id="info" onclick="ShowMissionInfoModal(${mission.MissionId})" class="btn btn-info btn-sm">Info</button>
                                                                     <button id="edit" onclick="" class="btn btn-primary btn-sm">Edit</button>
                                                                     <button id="delete" onclick="ShowMissionDeleteModal(${mission.MissionId})" class="btn btn-danger btn-sm">Delete</button>
                                                                 </td>
                                                             </tr>
                                                            `);
            });

        }
    });

});

function ShowMissionAdmirals(mission) {
    let template = "";
    for (var admiral of mission.Admirals) {
        template += `<li>
                                        ${admiral.Name}
                                        </li>`;
    }

    return template;
}

function ShowMissionPlanets(mission) {
    let template = "";
    for (var planet of mission.Planets) {
        template += `<li>
                                        ${planet.Name}
                                        </li>`;
    }

    return template;
}

function ShowMissionInfoModal(id) {
    $.ajax({
        type: "GET",
        url: `/api/Mission/?id=${id}`,
        data: "",
        dataType: "json",
        success: function (response) {
            $(document).ready(function () {
                $("#ArmadaModal").modal();
            });

            $("#modalBody").html(`<ul>
                                                     <li> <p class ="text-info"> <strong>Start Date:</strong> ${response
                    .StartDate} </p> </li>
                                                     <li> <p class ="text-info"> <strong>End Date:</strong> ${response
                    .EndDate} </p> </li>
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

function ShowMissionDeleteModal(id) {
    $(document).ready(function () {
        $("#ArmadaModal").modal();
    });

    $("#modalBody").html('<p class="text-danger"><strong>Are you sure you want to delete this?</strong></p>');

    $("#modalFooter").html(
        `
                                        <button type="button" onclick="DeleteMission(${id
        })" class="btn btn-danger deletebtn">Delete</button>
                                        <button type="button" class="btn btn-secondary close" data-bs-dismiss="modal">Cancel</button>
                                        `
    );

    $(".close").click(function () {
        $("#ArmadaModal").modal("hide");
    });
}

function DeleteMission(id) {
    $.ajax({
        type: "DELETE",
        url: `/api/Mission/?id=${id}`,
        data: "",
        dataType: "json",
        success: function (response) {
            setTimeout(() => $("#deleteAlert").html(`
                                                        <div class="alert alert-dismissible alert-warning">
                                                          <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                                                          <h4 class="alert-heading">Successfully deleted</h4>
                                                          <p class="mb-0">${response.Type}</p>
                                                        </div>
                                                    `).fadeOut(4000),
                500);
        }
    });
    $("#ArmadaModal").modal("hide");
    $(`#miss${id}`).remove();
}
