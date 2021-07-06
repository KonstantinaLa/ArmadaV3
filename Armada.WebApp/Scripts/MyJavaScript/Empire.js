//Create Table 
function CreateEmpireTable() {
    $("#TabContent").html(`
                                          <h2 class="m-4 text-center">Empires</h2>
                                            <table id="empireTable" class="table table-hover table-bordered">
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
                                       <button  onclick="ShowEmpireCreateModal()" class="btn btn-primary m-1">Create New</button>
                                        `);
}

function CreateEmpireFullTable() {
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
    }


$("#empireTablebtn").click(()=>CreateEmpireFullTable());

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

//Create Empire Section

function ShowEmpireCreateModal() {
    $(document).ready(function () {
        $("#ArmadaModal").modal();
    });

    EmpireAdmiralsTemplate();
    EmpireCreateModalBody();

    $("#modalFooter").html('<button type="button" class="btn btn-secondary close" data-bs-dismiss="modal">Cancel</button>');

    $(".close").click(function () {
        $("#ArmadaModal").modal("hide");
    });

    $("#empireCreateForm").submit((e) => e.preventDefault());

    CreateEmpire();

    $("#empireCreateForm").submit(() => $("#ArmadaModal").modal("hide"));

}

function EmpireCreateModalBody() {
    $("#modalBody").html(`
                                    <div class="col-md-8 mx-auto text-center">
                                         <form id="empireCreateForm">
                                           <fieldset>
                                               <legend>Register Emperor</legend>

                                               <div class="form-group">
                                                   <label class="col-form-label mt-4" for="Name">Name</label>
                                                   <input type="text" class="form-control" placeholder="Name" id="Name" autocomplete="off" required minlength="2" >
                                               </div>

                                               <div class="form-group">
                                                   <label class="col-form-label mt-4" for="Trait">Trait</label>
                                                   <input type="text" class="form-control" placeholder="Trait" id="Trait" autocomplete="off" required minlength="2">
                                               </div>

                                                <div class="form-group">
                                                   <label class="col-form-label mt-4" for="Systems">Controlled Systems</label>
                                                   <input type="number" class="form-control" placeholder="Controlled Systems" id="Systems" autocomplete="off" required min ="1">
                                               </div>

                                               <div class="form-group">
                                                   <label for="AdmiralSelect" class="form-label mt-4">Admirals</label>
                                                   <select  id="AdmiralSelect" class=" form-control"  multiple name="Admirals">
                                                    
                                                   </select>
                                               </div>


                                               <div class="form-group">
                                                   <label for="About" class="form-label mt-4">About</label>
                                                   <textarea class="form-control" id="About" rows="3" required minlength="10"></textarea>
                                               </div>
                                               <div class="form-group">
                                                   <label for="formFile" class="form-label mt-4">Photo</label>
                                                   <input class="form-control" type="file" id="formFile">
                                               </div>
                                                  <input type="submit" class="btn btn-primary mt-3"  value="Register"/>
                                              </fieldset>
                                         </form>
                                      </div>
                                  `);
}

function EmpireAdmiralsTemplate() {
    $.ajax({
        type: "GET",
        url: "/api/Admiral",
        data: "",
        dataType: "json",
        success: function (response) {
            
            response.forEach(function (admiral) {
                $("#AdmiralSelect").append(`
                                                       <option id="${admiral.AdmiralId}">${admiral.Name}</option>
                                               `);
            });
        }
    });
}

function CreateEmpire() {

   // var admirals = $.each($("#AdmiralSelect").children("option:selected"));

    $("#empireCreateForm").submit(() => {
        var empire = {
            "Name": $("#Name").val(),
            "Trait": $("#Trait").val(),
            "ControlledSystems": $("#Systems").val(),
            "Description": $("#About").val(),
           // "Admirals": $("#AdmiralSelect").val(),
            "Photo": null,
        };

        $.ajax({
            type: "POST",
            url: "/api/Empire",
            data: empire,
            dataType: "json",
            success: function (response) {
                $("#successAlert").html(`
                                       <div class="alert alert-dismissible alert-success">
                                           <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                                           <strong>Well done!</strong> You successfully Created  ${response.Name} !!
                                       </div>
                                              `);
                setTimeout(() => $("#successAlert").html('').fadeOut(4000), 4000);
                $("#empireTable").html(' ');
                CreateEmpireFullTable();
            }
        });
    });
}


//Empire Info Section
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


//Empire Delete Section
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