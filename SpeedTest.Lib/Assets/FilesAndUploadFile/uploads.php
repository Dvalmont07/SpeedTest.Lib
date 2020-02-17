<?php
   if(isset($_FILES['file']))
   {
    //#Atribui uma array com os nomes dos arquivos à variável
    $name = $_FILES['file']['name']; 
    $ext = strtolower(substr($name,-4));
    //#Atribui uma array com os nomes temporários dos arquivos à variável
    $tmp_name = $_FILES['file']['tmp_name']; 

    //#Directory wich will be upload the files
    $dir = 'uploads/';

    move_uploaded_file($tmp_name, $dir . $name);
    }
    else{
        die("Não foi possível executar o upload");
    }

?>