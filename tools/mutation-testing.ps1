Set-Location $PSScriptRoot\..

dotnet tool run dotnet-stryker --config-file "stryker-config.json" --reporter "html"

$test_report_folder_object = Get-ChildItem ".\StrykerOutput" | Where-Object { $_.PSIsContainer } | Sort-Object CreationTime -desc | Select-Object -f 1

if ($test_report_folder_object) {
    Invoke-Item "$test_report_folder_object\reports\mutation-report.html"
}