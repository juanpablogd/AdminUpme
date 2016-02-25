﻿$(document).ready(function () {

    console.log("ready document Prohect");
    jQuery.fn.ForceNumericOnly =
        function () {
            return this.each(function () {
                $(this).keydown(function (e) {
                    console.log(e.keyCode)
                    if (e.keyCode == 110 || e.keyCode == 190) {
                        e.preventDefault();
                        $(this).val($(this).val() + ',');
                    }
                    var key = e.charCode || e.keyCode || 0;
                    return (
                        key == 8 ||
                        key == 9 ||
                        key == 46 ||
                        key == 188 ||
                        (key >= 35 && key <= 40) ||
                        (key >= 48 && key <= 57) ||
                        (key >= 96 && key <= 105));

                });
            });
        };

    $('#NOMBRE').attr('maxlength', '150');

    $('#ID_ORGANIZACION').change(function () {
        console.log("Cambio de Organizacion");
        var input = $('<input>').attr('type', 'hidden').attr('name', 'chgSitio').val('true');
        $("form[action='/pcProyecto/Create']").append($(input));
        $("form[action='/pcProyecto/Create']").submit();
        
    });
        
    $('#PUESTA_MARCHA').pickadate({
        format: 'yyyy-mm-dd',
    })
    $('#INI_EJEC_INV').pickadate({
        format: 'yyyy-mm-dd',
    })
    $('#FIN_EJE_INV').pickadate({
        format: 'yyyy-mm-dd',
    })

    $("#NUM_TRANSFORMADORES").blur(function () {
        console.log(validarEntero($("#NUM_TRANSFORMADORES").val()));
        var valor = validarEntero($("#NUM_TRANSFORMADORES").val());
        $("#NUM_TRANSFORMADORES").val(valor);
    });

    $('#NIVEL_TENSION').change(function () {
        var nt = $(this).val();
        console.log("NIvel tensi;on  " + nt);
        if (nt == 3) {
            $("#n3").show();
            $("#n2").show();
        } else if (nt == 2) {
            $("#n3").hide();
            $("#n2").show();
        } else {
            $("#n3").hide();
            $("#n2").hide();
        }

    });

    $("#RED_MT_KM").blur(function () { console.log(RedondeoTresDec($("#RED_MT_KM").val())); var valor = RedondeoTresDec($("#RED_MT_KM").val()); $("#RED_MT_KM").val(valor); });
    $("#RED_MT_KM").ForceNumericOnly();

    $("#RED_BT_KM").blur(function () { console.log(RedondeoTresDec($("#RED_BT_KM").val())); var valor = RedondeoTresDec($("#RED_BT_KM").val()); $("#RED_BT_KM").val(valor); });
    $("#RED_BT_KM").ForceNumericOnly();

    $("#CU_MODIFICADO").blur(function () { console.log(RedondeoTresDec($("#CU_MODIFICADO").val())); var valor = RedondeoTresDec($("#CU_MODIFICADO").val()); $("#CU_MODIFICADO").val(valor); });
    $("#CU_MODIFICADO").ForceNumericOnly();

    $("#AOM_N1").blur(function () { console.log(validarEntero($("#AOM_N1").val())); var valor = validarEntero($("#AOM_N1").val()); $("#AOM_N1").val(valor); });
    $("#AOM_N1").ForceNumericOnly();
    $("#COSTO_MEDIO_N1").blur(function () { console.log(RedondeoTresDec($("#COSTO_MEDIO_N1").val())); var valor = RedondeoTresDec($("#COSTO_MEDIO_N1").val()); $("#COSTO_MEDIO_N1").val(valor); });
    $("#COSTO_MEDIO_N1").ForceNumericOnly();
    $("#INVERSION_N1").blur(function () { console.log(validarEntero($("#INVERSION_N1").val())); var valor = validarEntero($("#INVERSION_N1").val()); $("#INVERSION_N1").val(valor); });
    $("#INVERSION_N1").ForceNumericOnly();

    $("#AOM_N2").blur(function () { console.log(validarEntero($("#AOM_N2").val())); var valor = validarEntero($("#AOM_N2").val()); $("#AOM_N2").val(valor); });
    $("#AOM_N2").ForceNumericOnly();
    $("#COSTO_MEDIO_N2").blur(function () { console.log(RedondeoTresDec($("#COSTO_MEDIO_N2").val())); var valor = RedondeoTresDec($("#COSTO_MEDIO_N2").val()); $("#COSTO_MEDIO_N2").val(valor); });
    $("#COSTO_MEDIO_N2").ForceNumericOnly();
    $("#INVERSION_N2").blur(function () { console.log(validarEntero($("#INVERSION_N2").val())); var valor = validarEntero($("#INVERSION_N2").val()); $("#INVERSION_N2").val(valor); });
    $("#INVERSION_N2").ForceNumericOnly();

    $("#AOM_N3").blur(function () { console.log(validarEntero($("#AOM_N3").val())); var valor = validarEntero($("#AOM_N3").val()); $("#AOM_N3").val(valor); });
    $("#AOM_N3").ForceNumericOnly();
    $("#COSTO_MEDIO_N3").blur(function () { console.log(RedondeoTresDec($("#COSTO_MEDIO_N3").val())); var valor = RedondeoTresDec($("#COSTO_MEDIO_N3").val()); $("#COSTO_MEDIO_N3").val(valor); });
    $("#COSTO_MEDIO_N3").ForceNumericOnly();
    $("#INVERSION_N3").blur(function () { console.log(validarEntero($("#INVERSION_N3").val())); var valor = validarEntero($("#INVERSION_N3").val()); $("#INVERSION_N3").val(valor); });
    $("#INVERSION_N3").ForceNumericOnly();

    $('#NUM_TRANSFORMADORES').keydown(function (e) { //(event.keyCode< 48 || event.keyCode > 57
        console.log(e.keyCode);
        // Allow: backspace, delete, tab, escape, enter and .(190 NO 110) 
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13]) !== -1 ||
            // Allow: Ctrl+A, Command+A
            (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }

    });

    function validarEntero(valor) {
        //intento convertir a entero. 
        //si era un entero no le afecta, si no lo era lo intenta convertir 
        valor = parseInt(valor)
        //Compruebo si es un valor numérico 
        if (isNaN(valor)) {
            //entonces (no es numero) devuelvo el valor cadena vacia 
        } else {
            //En caso contrario (Si era un número) devuelvo el valor 
            return valor
        }
    }

    function RedondeoCuartoDec(valor) {
        valor = valor.toString().replace(",", ".");
        valor = Math.round(valor * 10000) / 10000
        valor = valor.toString().replace(".", ",");
        //Compruebo si es un valor numérico 
        if (isNaN(valor)) {
            //entonces (no es numero) devuelvo el valor cadena vacia 
            return valor
        } else {
            //En caso contrario (Si era un número) devuelvo el valor 
            return valor
        }
    }

    function RedondeoTresDec(valor) {
        valor = valor.toString().replace(",", ".");
        valor = Math.round(valor * 1000) / 1000
        valor = valor.toString().replace(".", ",");
        //Compruebo si es un valor numérico 
        if (isNaN(valor)) {
            //entonces (no es numero) devuelvo el valor cadena vacia 
            return valor
        } else {
            //En caso contrario (Si era un número) devuelvo el valor 
            return valor
        }
    }

    //VALIDADOR NUMERICO NECESARIO PARA ASP 
    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,1}(?:[\s\.,]\d{1})+)(?:[\.,]\d+)?$/.test(value);
    }

    $("form[action='/pcProyecto/Create']").submit(function (e) {
        console.log("uno es visible: " + $("#n1").is(':visible'));
        console.log("REALIZARA_PROYECTO: " + $("#REALIZARA_PROYECTO").val() );
        console.log("Variable para hacer validacion: " + $("input[name='chgSitio']").val());

        if ($("input[name='chgSitio']").val() != "true") {

            if ($("#NOMBRE").val() == "") {
                $("[data-valmsg-for='NOMBRE']").show();
                $("[data-valmsg-for='NOMBRE']").html("Debe diligenciar el Nombre");
                $("#NOMBRE").focus();
                e.preventDefault();
                return false;
            } else $("[data-valmsg-for='NOMBRE']").hide();

            if ($("#ID_ORGANIZACION").val() == "") {
                $("[data-valmsg-for='ID_ORGANIZACION']").show();
                $("[data-valmsg-for='ID_ORGANIZACION']").html("Debe Seleccionar la Organización");
                $("#ID_ORGANIZACION").focus();
                e.preventDefault();
                return false;
            } else $("[data-valmsg-for='ID_ORGANIZACION']").hide();

            if ($("#ID_SUBESTACION").val() == "") {
                $("[data-valmsg-for='ID_SUBESTACION']").show();
                $("[data-valmsg-for='ID_SUBESTACION']").html("Debe Seleccionar la SubEstación de la organización");
                $("#ID_SUBESTACION").focus();
                e.preventDefault();
                return false;
            } else $("[data-valmsg-for='ID_SUBESTACION']").hide();

            var realiza_proyecto = $("#REALIZARA_PROYECTO").val();
            if (realiza_proyecto == "" || realiza_proyecto == "undefined") {
                $("[data-valmsg-for='REALIZARA_PROYECTO']").show();
                $("[data-valmsg-for='REALIZARA_PROYECTO']").html("Debe Seleccionar la respuesta");
                $("#REALIZARA_PROYECTO").focus();
                e.preventDefault();
                return false;
            } else $("[data-valmsg-for='REALIZARA_PROYECTO']").hide();

            var admin_proyecto = $("#ADMIN_PROYECTO").val();
            if (admin_proyecto == "" || admin_proyecto == "undefined") {
                $("[data-valmsg-for='ADMIN_PROYECTO']").show();
                $("[data-valmsg-for='ADMIN_PROYECTO']").html("Debe Seleccionar la respuesta");
                $("#ADMIN_PROYECTO").focus();
                e.preventDefault();
                return false;
            } else $("[data-valmsg-for='ADMIN_PROYECTO']").hide();

            var financia_proyecto = $("#FINANCIA_ACOMETIDA").val();
            if (financia_proyecto == "" || financia_proyecto == "undefined") {
                $("[data-valmsg-for='FINANCIA_ACOMETIDA']").show();
                $("[data-valmsg-for='FINANCIA_ACOMETIDA']").html("Debe Seleccionar la respuesta");
                $("#FINANCIA_ACOMETIDA").focus();
                e.preventDefault();
                return false;
            } else $("[data-valmsg-for='FINANCIA_ACOMETIDA']").hide();

            if ($("#INI_EJEC_INV").val() == "") {
                $("[data-valmsg-for='INI_EJEC_INV']").show();
                $("[data-valmsg-for='INI_EJEC_INV']").html("Seleccione la Fecha Inicial de Ejecución");
                $("#INI_EJEC_INV").focus();
                e.preventDefault();
                return false;
            } else $("[data-valmsg-for='INI_EJEC_INV']").hide();

            if ($("#FIN_EJE_INV").val() == "") {
                $("[data-valmsg-for='FIN_EJE_INV']").show();
                $("[data-valmsg-for='FIN_EJE_INV']").html("Seleccione Fecha Final de Ejecución");
                $("#FIN_EJE_INV").focus();
                e.preventDefault();
                return false;
            } else $("[data-valmsg-for='FIN_EJE_INV']").hide();

            if ($("#PUESTA_MARCHA").val() == "") {
                $("[data-valmsg-for='PUESTA_MARCHA']").show();
                $("[data-valmsg-for='PUESTA_MARCHA']").html("Seleccione Fecha de Puesta en Marcha");
                $("#PUESTA_MARCHA").focus();
                e.preventDefault();
                return false;
            } else $("[data-valmsg-for='PUESTA_MARCHA']").hide();

            if ($("#NUM_TRANSFORMADORES").val() == "") {
                $("[data-valmsg-for='NUM_TRANSFORMADORES']").show();
                $("[data-valmsg-for='NUM_TRANSFORMADORES']").html("Digite un número Positivo");
                $("#NUM_TRANSFORMADORES").focus();
                e.preventDefault();
                return false;
            } else if ($("#NUM_TRANSFORMADORES").val() < 0) {
                $("[data-valmsg-for='NUM_TRANSFORMADORES']").show();
                $("[data-valmsg-for='NUM_TRANSFORMADORES']").html("Digite un número Positivo");
                $("#NUM_TRANSFORMADORES").focus();
                e.preventDefault();
                return false;
            } else $("[data-valmsg-for='NUM_TRANSFORMADORES']").hide();

            if ($("#n1").is(':visible')) {
                if ($("#AOM_N1").val() == "") {
                    $("[data-valmsg-for='AOM_N1']").show();
                    $("[data-valmsg-for='AOM_N1']").html("Digite un número entero positivo.");
                    $("#AOM_N1").focus();
                    e.preventDefault();
                    return false;
                } else $("[data-valmsg-for='AOM_N1']").hide();

                if ($("#COSTO_MEDIO_N1").val() == "") {
                    $("[data-valmsg-for='COSTO_MEDIO_N1'").show();
                    $("[data-valmsg-for='COSTO_MEDIO_N1'").html("Debe diligenciar el campo");
                    $("#COSTO_MEDIO_N1").focus();
                    e.preventDefault();
                    return false;
                } else $("[data-valmsg-for='COSTO_MEDIO_N1']").hide();

                if ($("#INVERSION_N1").val() == "") {
                    $("[data-valmsg-for='INVERSION_N1'").show();
                    $("[data-valmsg-for='INVERSION_N1'").html("Digite un número entero positivo.");
                    $("#INVERSION_N1").focus();
                    e.preventDefault();
                    return false;
                } else $("[data-valmsg-for='INVERSION_N1']").hide();
            }
            if ($("#n2").is(':visible')) {
                if ($("#AOM_N2").val() == "") {
                    $("[data-valmsg-for='AOM_N2']").show();
                    $("[data-valmsg-for='AOM_N2']").html("Digite un número entero positivo.");
                    $("#AOM_N2").focus();
                    e.preventDefault();
                    return false;
                } else $("[data-valmsg-for='AOM_N2']").hide();

                if ($("#COSTO_MEDIO_N2").val() == "") {
                    $("[data-valmsg-for='COSTO_MEDIO_N2'").show();
                    $("[data-valmsg-for='COSTO_MEDIO_N2'").html("Debe diligenciar el campo");
                    $("#COSTO_MEDIO_N2").focus();
                    e.preventDefault();
                    return false;
                } else $("[data-valmsg-for='COSTO_MEDIO_N2']").hide();

                if ($("#INVERSION_N2").val() == "") {
                    $("[data-valmsg-for='INVERSION_N2'").show();
                    $("[data-valmsg-for='INVERSION_N2'").html("Digite un número entero positivo.");
                    $("#INVERSION_N2").focus();
                    e.preventDefault();
                    return false;
                } else $("[data-valmsg-for='INVERSION_N2']").hide();
            }
            if ($("#n3").is(':visible')) {
                if ($("#AOM_N3").val() == "") {
                    $("[data-valmsg-for='AOM_N3']").show();
                    $("[data-valmsg-for='AOM_N3']").html("Digite un número entero positivo.");
                    $("#AOM_N3").focus();
                    e.preventDefault();
                    return false;
                } else $("[data-valmsg-for='AOM_N3']").hide();

                if ($("#COSTO_MEDIO_N3").val() == "") {
                    $("[data-valmsg-for='COSTO_MEDIO_N3'").show();
                    $("[data-valmsg-for='COSTO_MEDIO_N3'").html("Debe diligenciar el campo");
                    $("#COSTO_MEDIO_N3").focus();
                    e.preventDefault();
                    return false;
                } else $("[data-valmsg-for='COSTO_MEDIO_N3']").hide();

                if ($("#INVERSION_N3").val() == "") {
                    $("[data-valmsg-for='INVERSION_N3'").show();
                    $("[data-valmsg-for='INVERSION_N3'").html("Digite un número entero positivo.");
                    $("#INVERSION_N3").focus();
                    e.preventDefault();
                    return false;
                } else $("[data-valmsg-for='INVERSION_N3']").hide();
            }

            if ($("#CU_MODIFICADO").val() == "") {
                $("[data-valmsg-for='CU_MODIFICADO']").show();
                $("[data-valmsg-for='CU_MODIFICADO']").html("Digite un número Positivo");
                $("#CU_MODIFICADO").focus();
                e.preventDefault();
                return false;
            } else if ($("#CU_MODIFICADO").val() < 0) {
                $("[data-valmsg-for='CU_MODIFICADO']").show();
                $("[data-valmsg-for='CU_MODIFICADO']").html("Digite un número Positivo");
                $("#CU_MODIFICADO").focus();
                e.preventDefault();
                return false;
            } else $("[data-valmsg-for='CU_MODIFICADO']").hide();

            //LIMPIA LOS CAMPOS
            console.log("NT Val: " + $("#NIVEL_TENSION").val());

            if ($("#NIVEL_TENSION").val() == "1") {
                console.log("NT 1");
                $("#AOM_N2").val("");
                $("#COSTO_MEDIO_N2").val("");
                $("#INVERSION_N2").val("");
                $("#AOM_N3").val("");
                $("#COSTO_MEDIO_N3").val("");
                $("#INVERSION_N3").val("");
            } else if ($("#NIVEL_TENSION").val() == "2") {
                console.log("NT 2");
                $("#AOM_N3").val("");
                $("#COSTO_MEDIO_N3").val("");
                $("#INVERSION_N3").val("");
            }
            //e.preventDefault();
        }
    });

    //CODIGO QUE ACTIVA LOS CONTROLES SEGUN EL NIVEL DE TENSION
    if ($("#NIVEL_TENSION").val() == "1") {
        $("#n1").show();
        $("#n2").hide();
        $("#n3").hide();
    } else if ($("#NIVEL_TENSION").val() == "2") {
        $("#n1").show();
        $("#n2").show();
        $("#n3").hide();
    } else if ($("#NIVEL_TENSION").val() == "3") {
        $("#n1").show();
        $("#n2").show();
        $("#n3").show();
    }

});