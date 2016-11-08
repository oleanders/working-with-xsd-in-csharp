$xsdFolder = "Models\Xsd\"
$xsds = @(
    'https://raw.githubusercontent.com/FINTprosjektet/fint-informasjonsmodell/master/xsd/1.0/FINT/Felles/fintfelles.xsd',
    'https://raw.githubusercontent.com/FINTprosjektet/fint-informasjonsmodell/master/xsd/1.0/FINT/Arbeidstaker/arbeidstaker.xsd'
)
$xsdTool = "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\xsd.exe"

# DOWNLOAD FILES TO XSD FOLDER
foreach($xsd in $xsds){
    $filename = [System.IO.Path]::GetFileName($xsd);
    (New-Object Net.WebClient).DownloadFile($xsd, $xsdFolder + $filename)
}

# GENERATE CS-file from XSD
$args = @('/classes', "/o:$xsdFolder..")
& $xsdTool ((Get-ChildItem $xsdFolder | ForEach-Object { $xsdFolder + $_.Name }) + $args)
