"use strict";var KTModalCreateApiKey=function(){var t,e,n,o,i,r;return{init:function(){(r=document.querySelector("#kt_modal_create_api_key"))&&(i=new bootstrap.Modal(r),o=document.querySelector("#kt_modal_create_api_key_form"),t=document.getElementById("kt_modal_create_api_key_submit"),e=document.getElementById("kt_modal_create_api_key_cancel"),$(o.querySelector('[name="category"]')).on("change",(function(){n.revalidateField("category")})),n=FormValidation.formValidation(o,{fields:{name:{validators:{notEmpty:{message:"API name is required"}}},description:{validators:{notEmpty:{message:"Description is required"}}},category:{validators:{notEmpty:{message:"Country is required"}}},method:{validators:{notEmpty:{message:"API method is required"}}}},plugins:{trigger:new FormValidation.plugins.Trigger,bootstrap:new FormValidation.plugins.Bootstrap5({rowSelector:".fv-row",eleInvalidClass:"",eleValidClass:""})}}),t.addEventListener("click",(function(e){e.preventDefault(),n&&n.validate().then((function(e){console.log("validated!"),"Valid"==e?(t.setAttribute("data-kt-indicator","on"),t.disabled=!0,setTimeout((function(){t.removeAttribute("data-kt-indicator"),t.disabled=!1,Swal.fire({text:"Form has been successfully submitted!",icon:"success",buttonsStyling:!1,confirmButtonText:"เรียบร้อย!",customClass:{confirmButton:"btn btn-primary"}}).then((function(t){t.isConfirmed&&i.hide()}))}),2e3)):Swal.fire({text:"Sorry, looks like there are some errors detected, please try again.",icon:"error",buttonsStyling:!1,confirmButtonText:"เรียบร้อย!",customClass:{confirmButton:"btn btn-primary"}})}))})),e.addEventListener("click",(function(t){t.preventDefault(),Swal.fire({text:"Are you sure you would like to cancel?",icon:"warning",showCancelButton:!0,buttonsStyling:!1,confirmButtonText:"Yes, cancel it!",cancelButtonText:"No, return",customClass:{confirmButton:"btn btn-primary",cancelButton:"btn btn-active-light"}}).then((function(t){t.value?(o.reset(),i.hide()):"cancel"===t.dismiss&&Swal.fire({text:"Your form has not been cancelled!.",icon:"error",buttonsStyling:!1,confirmButtonText:"เรียบร้อย!",customClass:{confirmButton:"btn btn-primary"}})}))})))}}}();KTUtil.onDOMContentLoaded((function(){KTModalCreateApiKey.init()}));