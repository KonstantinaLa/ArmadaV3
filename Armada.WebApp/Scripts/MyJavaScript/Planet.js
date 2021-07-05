//Planet


//Table Creation Section
function CreatePlanetTableHead() {
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
                                       <button id="create" onclick="ShowPlanetCreateModal" class="btn btn-primary m-1">Create New</button>
                                        `);
}

function CreatePlanetFullTable() {
    
    $.ajax({
        type: "GET",
        url: "/api/Planet",
        data: "",
        dataType: "json",
        success: function (response) {
            CreatePlanetTableHead();
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
}

$("#planetTablebtn").click(CreatePlanetFullTable);


//Create Planet Section
function ShowPlanetCreateModal() {
    console.log("createModal");

    $(document).ready(function () {
        $("#ArmadaModal").modal();
    });

    //planet-mission template

    PlanetCreateModalBody()

    $("#modalFooter")
        .html('<button type="button" class="btn btn-secondary close" data-bs-dismiss="modal">Cancel</button>');

    $(".close").click(function () {
        $("#ArmadaModal").modal("hide");
    });

    $("#planetCreateForm").submit((e) => e.preventDefault());

    CreatePlanet();

    $("#planetCreateForm").submit(() => $("#ArmadaModal").modal("hide"));
}

function CreatePlanet() {

    $("#planetCreateForm").submit(() => {
        var planet = {
            "Name": $("#Name").val(),
            "StarSystem": $("#StarSystem").val(),
            "Type": $("#Type").val(),
            "Mission":null

        };

        $.ajax({
            type: "POST",
            url: "/api/Planet",
            data: planet,
            dataType: "json",
            success: function (response) {
                $("#successAlert").html(`
                                       <div class="alert alert-dismissible alert-success">
                                           <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                                           <strong>Well done!</strong> You successfully Created  ${response.Name} !!
                                       </div>
                                              `);
                setTimeout(() => $("#successAlert").html('').fadeOut(4000), 4000);
                $("#emperorTable").html(' ');
                CreatePlanetFullTable();
            }
        });
    });
}


function PlanetCreateModalBody() {
    $("#modalBody").html(`
                                    <div class="col-md-8 mx-auto text-center">
                                         <form id="planetCreateForm">
                                           <fieldset>
                                               <legend>Create Planet</legend>

                                               <div class="form-group">
                                                   <label class="col-form-label mt-4" for="Name">Name</label>
                                                   <input type="text" class="form-control" placeholder="Name" id="Name" autocomplete="off" required minlength="2" >
                                               </div>

                                               <div class="form-group">
                                                   <label class="col-form-label mt-4" for="StarSystem">Star System</label>
                                                   <input type="text" class="form-control" placeholder="StarSystem" id="StarSystem" autocomplete="off" required min ="2">
                                               </div>

                                               <div class="form-group">
                                                   <label for="MissionSelect" class="form-label mt-4">Missions</label>
                                                   <select class="form-select" id="MissionSelect">
                                                    
                                                   </select>
                                               </div>
                                               <div class="form-group">
                                                   <label for="TypeSelect" class="form-label mt-4">Type</label>
                                                   <select class="form-select" required id="TypeSelect">
                                                    
                                                   </select>
                                               </div>
                                                  <input type="submit" class="btn btn-primary mt-3"  value="Register"/>
                                              </fieldset>
                                         </form>
                                      </div>
                                  `);
}



//Edit Planet Section






function ShowPlanetMissions(planet) {
    let template = "";
    for (var mission of planet.Missions) {
        template += `<li>
                                        ${mission.Type}</li>`;
    }

    return template;
}

//Info Planet Section
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


//Delete Planet Section

function ShowPlanetDeleteModal(id) {
    $(document).ready(function () {
        $("#ArmadaModal").modal();
    });

    $("#modalBody").html('<p class="text-danger"><strong>Are you sure you want to delete this?</strong></p>');

    $("#modalFooter").html(
        `
                                        <button type="button" onclick="DeletePlanet(${id})" class="btn btn-danger deletebtn">Delete</button>
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

            $("#deleteAlert").html(`
                                                        <div class="alert alert-dismissible alert-warning msg">
                                                          <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                                                          <h4 class="alert-heading">Successfully deleted</h4>
                                                          <p class="mb-0">${response.Name}</p>
                                                        </div>
                                                    `)


            setTimeout(() => ($(".msg").fadeOut(800)), 2000);
        }
    });
    $("#ArmadaModal").modal("hide");
    $(`#pl${id}`).remove();
}
