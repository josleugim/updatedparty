<?php

$mail_destinatario = 'jmiguel@mipipol.com.mx';

if (isset ($_POST['enviar'])) {
$headers .= "From: ".$_POST['email']. "rn";
if ( mail ($mail_destinatario, $_POST['asunto'], "Nombre y apellidos : ".$_POST['nombre']." Asunto: ".stripcslashes ($_POST['asunto'])."n Mensaje :n ".stripcslashes ($_POST['mensaje']), $headers )) echo '

Su mensaje a sido enviado correctamente. Gracias por contactar con nosostros

'; 

else echo '

Error al enviar el formulario. Por favor, inténtelo de nuevo mas tarde.

'; } 

echo '


';
?>