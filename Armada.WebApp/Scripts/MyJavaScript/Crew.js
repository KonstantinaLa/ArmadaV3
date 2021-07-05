//Crew


//Table Creation Section
function CreateCrewTableHead() {
    $("#TabContent").html(`
                                  <h2 class="m-4 text-center">Crew</h2>
                                   <table class="table table-hover table-bordered">
                                       <thead>
                                           <tr>
                                               <th>Number</th>
                                               <th>Specialty</th>
                                               <th>Admiral</th>
                                               <th>Actions</th>
                                           </tr>
                                       </thead>
                                       <tbody id="crewBody">
                                   </tbody>
                                </table>
                               <button id="create" onclick="" class="btn btn-primary m-1">Create New</button>
                                        `);
}

function CreateCrewFullTable() {

    $.ajax({
        type: "GET",
        url: "/api/Crew",
        data: "",
        dataType: "json",
        success: function (response) {
            CreateCrewTableHead();
            response.forEach(function (crew) {
                $("#crewBody").append(`
                                           <tr id=crew${crew.CrewId}>
                                               <td>
                                                   ${crew.Number}
                                               </td>
                                               <td>
                                                   ${crew.Specialty}
                                               </td>
                                                  <td>
                                                   ${crew.Admiral}
                                               </td>

                                               <td>
                                                   <button id="info" onclick="ShowCrewInfoModal(${crew.CrewId})" class="btn btn-info btn-sm">Info</button>
                                                   <button id="edit" onclick="(${crew.CrewId})" class="btn btn-primary btn-sm">Edit</button>
                                                   <button id="delete" onclick="ShowCrewDeleteModal(${crew.CrewId})" class="btn btn-danger btn-sm">Delete</button>
                                               </td>
                                           </tr>
                                                            `);
            });
        }
    });
}
$("#crewTablebtn").click(CreateCrewFullTable);


//Create Crew Section

//function ShowCreaCreateModal() {
//    $(document).ready(function () {
//        $("#ArmadaModal").modal();
//    });


//    CrewCreateModalBody();



//}

//function CrewCreateModalBody() {
//    $("#modalBody").html(`
//                                    <div class="col-md-8 mx-auto text-center">
//                                         <form id="empCreateForm">
//                                           <fieldset>
//                                               <legend>Register Emperor</legend>

//                                               <div class="form-group">
//                                                   <label class="col-form-label mt-4" for="Number">Number</label>
//                                                   <input type="number" class="form-control" placeholder="Number" id="Number" autocomplete="off" required min ="18">
//                                               </div>
//                                               <div class="form-group">
//                                                   <label for="Specialty" class="form-label mt-4">Specialty</label>
//                                                   <textarea class="form-control" id="Specialty" rows="3" required minlength="10"></textarea>
//                                               </div>
//                                                  <input type="submit" class="btn btn-primary mt-3"  value="Register"/>
//                                              </fieldset>
//                                         </form>
//                                      </div>
//                                  `);
//}











//Info Crew Section

function ShowCrewInfoModal(id) {
    $.ajax({
        type: "GET",
        url: `/api/Crew/?id=${id}`,
        data: "",
        dataType: "json",
        success: function (response) {
            $(document).ready(function () {
                $("#ArmadaModal").modal();
            });

            $("#modalBody").html(`<ul>
                                                     <li><p class ="text-info">  <strong>Crew Number:</strong> ${response.Number}</p> </li>
                                                     <li><p class ="text-info">  <strong>Specialty:</strong> ${response.Specialty}</p> </li>
                                                     <li><p class ="text-info">   <strong>Admiral in charge:</strong> ${response.Admiral}</p></li>
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


//Delete Crew Section
function ShowCrewDeleteModal(id) {
    $(document).ready(function () {
        $("#ArmadaModal").modal();
    });

    $("#modalBody").html('<p class="text-danger"><strong>Are you sure you want to delete this?</strong></p>');

    $("#modalFooter").html(
        `
                                        <button type="button" onclick="DeleteCrew(${id
        })" class="btn btn-danger deletebtn">Delete</button>
                                        <button type="button" class="btn btn-secondary close" data-bs-dismiss="modal">Cancel</button>
                                        `
    );

    $(".close").click(function () {
        $("#ArmadaModal").modal("hide");
    });
}

function DeleteCrew(id) {
    $.ajax({
        type: "DELETE",
        url: `/api/Crew/?id=${id}`,
        data: "",
        dataType: "json",
        success: function (response) {
            $("#deleteAlert").html(`
                                                        <div class="alert alert-dismissible alert-warning msg">
                                                          <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                                                          <h4 class="alert-heading">Successfully deleted</h4>
                                                          <p class="mb-0">${response.Specialty}</p>
                                                        </div>
                                                    `)
            setTimeout(() => ($(".msg").fadeOut(800)), 2000);
        }
    });
    $("#ArmadaModal").modal("hide");
    $(`#crew${id}`).remove();
}