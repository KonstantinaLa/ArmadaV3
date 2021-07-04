
//Emperor

//Table Creation Section
function CreateEmperorTableHead() {
    $("#TabContent").html(`
                                             <h2 class="m-4 text-center">Emperors</h2>
                                            <table class="table table-hover table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Photo</th>
                                                        <th>Name</th>
                                                        <th>Age</th>
                                                        <th>Empire</th>
                                                        <th>Actions</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="emperorsBody">
                                            </tbody>
                                         </table>
                                      <button id="create" onclick="ShowEmperorCreateModal()" class="btn btn-primary m-1">Create New</button>
                                        `);
}

function CreateEmperorFullTable() {

    $.ajax({
        type: "GET",
        url: "/api/Emperor",
        data: "",
        dataType: "json",
        success: function (response) {
            CreateEmperorTableHead();
            response.forEach(function (emperor) {
                $("#emperorsBody").append(`
                                              <tr id=emp${emperor.EmperorId}>
                                                  <td>
                                                      ${emperor.Photo}
                                                  </td>
                                                  <td>
                                                      ${emperor.Name}
                                                  </td>
                                                  <td>
                                                      ${emperor.Age}
                                                  </td>
                                                  <td>
                                                      ${emperor.Empire}
                                                  </td>
                                                  <td>
                                                      <button id="info" onclick="ShowEmperorInfoModal(${emperor.EmperorId})" class="btn btn-info btn-sm">Info</button>
                                                      <button id="edit" onclick="ShowEmperorEditModal(${emperor.EmperorId})" class="btn btn-primary btn-sm">Edit</button>
                                                      <button id="delete" onclick="ShowEmperorDeleteModal(${emperor.EmperorId})" class="btn btn-danger btn-sm">Delete</button>
                                                  </td>
                                           </tr>
                                          `);
            });

        }
    });
}

$("#emperorTablebtn").click(CreateEmperorFullTable);

//Create Emperor Section
function ShowEmperorCreateModal() {
    $(document).ready(function () {
        $("#ArmadaModal").modal();
    });
    EmperorEmpiresTemplate();

    EmperorCreateModalBody();

    $("#modalFooter")
        .html('<button type="button" class="btn btn-secondary close" data-bs-dismiss="modal">Cancel</button>');

    $(".close").click(function () {
        $("#ArmadaModal").modal("hide");
    });

    $("#empCreateForm").submit((e) => e.preventDefault());

    CreateEmperor();

    $("#empCreateForm").submit(() => $("#ArmadaModal").modal("hide"));

    $("#empCreateForm").submit(() => CreateEmperorFullTable());

}

function EmperorCreateModalBody() {
    $("#modalBody").html(`
                                    <div class="col-md-8 mx-auto text-center">
                                         <form id="empCreateForm">
                                           <fieldset>
                                               <legend>Register Emperor</legend>

                                               <div class="form-group">
                                                   <label class="col-form-label mt-4" for="Name">Name</label>
                                                   <input type="text" class="form-control" placeholder="Name" id="Name" autocomplete="off" required minlength="2" >
                                               </div>

                                               <div class="form-group">
                                                   <label class="col-form-label mt-4" for="Age">Age</label>
                                                   <input type="number" class="form-control" placeholder="Age" id="Age" autocomplete="off" required min ="18">
                                               </div>

                                               <div class="form-group">
                                                   <label for="EmpireSelect" class="form-label mt-4">Empire</label>
                                                   <select class="form-select" id="EmpireSelect">
                                                    
                                                   </select>
                                               </div>
                                               <div class="form-group">
                                                   <label for="SpeciesSelect" class="form-label mt-4">Species</label>
                                                   <select class="form-select" id="SpeciesSelect">
                                                    
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

function EmperorEmpiresTemplate() {
    $.ajax({
        type: "GET",
        url: "/api/Empire",
        data: "",
        dataType: "json",
        success: function (response) {

            var empireWithoutEmperors = response.filter(e => e.Emperor == null);
            empireWithoutEmperors.forEach(function (empire) {
                $("#EmpireSelect").append(`
                                                       <option id="${empire.EmpireId}">${empire.Name}</option>
                                               `);
            });
        }
    });

}


function CreateEmperor() {

    $("#empCreateForm").submit(() => {
        var emperor = {
            "EmperorId": $("#EmpireSelect").children(":selected").attr("id"),
            "Name": $("#Name").val(),
            "Age": $("#Age").val(),
            "Description": $("#About").val(),
            "Photo": null,

        };

        $.ajax({
            type: "POST",
            url: "/api/Emperor",
            data: emperor,
            dataType: "json",
            success: function (response) {
                $("#successAlert").html(`
                                       <div class="alert alert-dismissible alert-success">
                                           <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                                           <strong>Well done!</strong> You successfully Created  ${response.Name} !!
                                       </div>
                                              `);
                setTimeout(() => $("#successAlert").html('').fadeOut(4000), 4000);
            }
        });
    });
}

//Edit Emperor Section

function ShowEmperorEditModal(id) {
    $(document).ready(function () {
        $("#ArmadaModal").modal();
    });

    EmperorEmpiresTemplate();

    EmperorEditModalBody(id);

    $("#modalFooter")
        .html('<button type="button" class="btn btn-secondary close" data-bs-dismiss="modal">Cancel</button>');

    $(".close").click(function () {
        $("#ArmadaModal").modal("hide");
    });

    $("#empForm").submit((e) => e.preventDefault());

    EditEmperor(id);

    $("#empForm").submit(() => $("#ArmadaModal").modal("hide"));

    $("#empForm").submit(() => CreateEmperorFullTable());

}

function EmperorEditModalBody(id) {
    $.ajax({
        type: "GET",
        url: `/api/Emperor/?id=${id}`,
        data: "",
        dataType: "json",
        success: function (response) {
            $("#modalBody").html(`
                                    <div class="col-md-8 mx-auto text-center">
                                         <form id="empEditForm">
                                           <fieldset>
                                               <legend>Edit Emperor</legend>

                                               <div class="form-group">
                                                   <label class="col-form-label mt-4" for="Name">Name</label>
                                                   <input type="text" class="form-control" placeholder="Name" id="Name" value=${response.Name} autocomplete="off" required minlength="2" >
                                               </div>

                                               <div class="form-group">
                                                   <label class="col-form-label mt-4" for="Age">Age</label>
                                                   <input type="number" class="form-control" placeholder="Age" id="Age" value=${response.Age} autocomplete="off" required min ="18">
                                               </div>

                                               <div class="form-group">
                                                   <label for="SpeciesSelect" class="form-label mt-4">Species</label>
                                                   <select class="form-select" id="SpeciesSelect">
                                                    <option id=${response.Species}>${response.Species}</option>
                                                   </select>
                                               </div>

                                               <div class="form-group">
                                                   <label for="EmpireSelect" class="form-label mt-4">Empire</label>
                                                   <select class="form-select" id="EmpireSelect">
                                                    <option id=${response.EmpireId}>${response.EmpireName}</option>
                                                   </select>
                                               </div>
                                               <div class="form-group">
                                                   <label for="About" class="form-label mt-4">About</label>
                                                   <textarea class="form-control" id="About" rows="3"  required minlength="10">${response.Description}</textarea>
                                               </div>
                                               <div class="form-group">
                                                   <label for="formFile" class="form-label mt-4">Photo</label>
                                                   <input class="form-control" type="file" id="formFile">
                                               </div>
                                                  <input type="submit" class="btn btn-primary mt-3  value="Register"/>
                                              </fieldset>
                                         </form>
                                      </div>
                                  `);
        }
    });


}


function EditEmperor(id) {

    $("#empForm").submit(() => {
        var emperor = {
            "EmperorId": $("#EmpireSelect").children(":selected").attr("id"),
            "Name": $("#Name").val(),
            "Age": $("#Age").val(),
            "Description": $("#About").val(),
            "Photo": null,

        };

        $.ajax({
            type: "PUT",
            url: `/api/Emperor/?id=${id}`,
            data: emperor,
            dataType: "json",
            success: function (response) {
                $("#successAlert").html(`
                                       <div class="alert alert-dismissible alert-success">
                                           <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                                           <strong>Well done!</strong> You successfully Edited  ${response.Name} !!
                                       </div>
                                              `);
                setTimeout(() => $("#successAlert").html('').fadeOut(4000), 4000);
            }
        });
    });
}


//Info Emperor Section
function ShowEmperorInfoModal(id) {
    $.ajax({
        type: "GET",
        url: `/api/Emperor/?id=${id}`,
        data: "",
        dataType: "json",
        success: function (response) {
            $(document).ready(function () {
                $("#ArmadaModal").modal();
            });

            $("#modalBody").html(`<ul>
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

//Delete Emperor Section
function ShowEmperorDeleteModal(id) {
    $(document).ready(function () {
        $("#ArmadaModal").modal();
    });

    $("#modalBody").html('<p class="text-danger"><strong>Are you sure you want to delete this?</strong></p>');

    $("#modalFooter").html(
        `
                                        <button type="button" onclick="DeleteEmperor(${id
        })"class="btn btn-danger deletebtn">Delete</button>
                                        <button type="button" class="btn btn-secondary close" data-bs-dismiss="modal">Cancel</button>
                                        `
    );

    $(".close").click(function () {
        $("#ArmadaModal").modal("hide");
    });
}

function DeleteEmperor(id) {
    $.ajax({
        type: "DELETE",
        url: `/api/Emperor/?id=${id}`,
        data: "",
        dataType: "json",
        success: function (response) {
            setTimeout(() => $("#deleteAlert").html(`
                                                        <div class="alert alert-dismissible alert-warning">
                                                          <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                                                          <h4 class="alert-heading">Successfully deleted</h4>
                                                          <p class="mb-0">${response.Name}</p>
                                                        </div>
                                                    `).fadeOut(4000),500);
        }
    });

    $("#ArmadaModal").modal("hide");
    $(`#emp${id}`).remove();
}
