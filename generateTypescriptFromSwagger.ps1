# http://localhost:5117/swagger/v1/swagger.json


# Replace the URL with the actual API endpoint
$apiUrl = "http://localhost:5117/swagger/v1/swagger.json"

$fileName = "swagger.json"

# Make the request and save the response to a file
Invoke-RestMethod -Uri $apiUrl -OutFile $fileName

# Check if the request was successful

if (Test-Path $fileName) {
    Write-Host "File exists."
} else {
    Write-Host "File does not exist."
    return
}

npx swagger-typescript-api -p $fileName -n swaggerExport.ts

