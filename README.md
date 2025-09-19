# Weather App - Deploying .NET 8 API to Azure Kubernetes Service (AKS)

This project shows how to build, containerize, and deploy a simple **.NET 8 Web API** to **Azure Kubernetes Service (AKS)** using **Docker, Azure Container Registry (ACR), and GitHub Actions CI/CD**.

---

## 📖 Overview
- **.NET 8 Web API** with RESTful endpoints and Swagger
- **Dockerized** application for consistency
- **Azure Container Registry (ACR)** to store container images
- **Azure Kubernetes Service (AKS)** for scaling and self-healing
- **GitHub Actions** for automated CI/CD pipeline

---

## 🛠️ Prerequisites
Make sure you have:
- [Visual Studio Code](https://code.visualstudio.com/)
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)
- [kubectl](https://kubernetes.io/docs/tasks/tools/)
- [GitHub account](https://github.com)
- [Azure account](https://azure.microsoft.com/free/)

---

## 📂 Project Structure

```text
WeatherApp/
│
├── WeatherApp.csproj             # Project file
├── Program.cs                    # API entrypoint
├── Dockerfile                    # Docker build config
├── appsettings.json              # Config file
│
├── k8s/                          # Kubernetes manifests
│   ├── deployment.yaml
│   └── service.yaml
│
└── .github/workflows/deploy.yml  # GitHub Actions workflow
```

## 🚀 Step-by-Step Deployment

### 1. Run Locally

`dotnet build`
`dotnet run`

2. Build Docker Image

`docker build -t weather-app:local .`
`docker run -p 8080:8080 weather-app:local`

3. Push Image to ACR

`az login`
`az acr create --resource-group student-demo --name <your-acr-name> --sku Basic`
`az acr build --registry <your-acr-name> --image weather-app:latest .`

4. Deploy to AKS

`az aks create --resource-group student-demo --name student-aks-cluster --node-count 1 --attach-acr <your-acr-name>`
`az aks get-credentials --resource-group student-demo --name student-aks-cluster`
`kubectl apply -f k8s/`

5. Access the App

`kubectl get service weather-app-service --watch`

Copy the EXTERNAL-IP and test in your browser:

`/` → Welcome message

`/weather` → Weather data

`/health` → Health endpoint

`/swagger` → API documentation

CI/CD with GitHub Actions
Workflow triggers on push to main branch

Steps:

Build and test .NET app

Build Docker image

Push image to ACR

Deploy to AKS

GitHub secrets required:

AZURE_CREDENTIALS

ACR_NAME

RESOURCE_GROUP

CLUSTER_NAME

🧹 Clean Up
To avoid charges, delete all resources:

`az group delete --name student-demo --yes --no-wait`

What You Achieved

Built a .NET 8 Web API

Containerized with Docker

Deployed to AKS with ACR

Automated deployments with GitHub Actions

📚 Next Steps
Add a database (Azure SQL or PostgreSQL)

Use ConfigMaps and Secrets in Kubernetes

Add monitoring with Azure Application Insights

Explore Terraform or Bicep for Infrastructure as Code
