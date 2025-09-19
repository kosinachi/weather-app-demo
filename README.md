# 🌤️ Weather App - Azure Kubernetes Service (AKS) Deployment

This project demonstrates how to build, containerize, and deploy a simple **.NET 8 Web API** to **Azure Kubernetes Service (AKS)** with **GitHub Actions CI/CD**.

---

## What you will Learn
- Build a production-ready **.NET Web API**
- Package your app into a **Docker container**
- Store images in **Azure Container Registry (ACR)**
- Deploy and scale your app on **Azure Kubernetes Service (AKS)**
- Automate deployments with **GitHub Actions**

---

## Prerequisites
Before starting, make sure you have:
- [Visual Studio Code](https://code.visualstudio.com/)
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)
- [kubectl](https://kubernetes.io/docs/tasks/tools/)
- [Git](https://git-scm.com/)
- [GitHub account](https://github.com/)
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

## Step-by-Step Guide

### 1 Build and Test Locally
```bash
dotnet build
dotnet run

2 Containerize with Docker
docker build -t weather-app:local .
docker run -p 8080:8080 weather-app:local

3 Push Image to Azure Container Registry
az login
az acr create --resource-group student-demo --name <your-acr-name> --sku Basic
az acr build --registry <your-acr-name> --image weather-app:latest .

4 Deploy to AKS
az aks create --resource-group student-demo --name student-aks-cluster --node-count 1 --attach-acr <your-acr-name>
az aks get-credentials --resource-group student-demo --name student-aks-cluster
kubectl apply -f k8s/

5 Automate with GitHub Actions
Add GitHub secrets:

AZURE_CREDENTIALS

ACR_NAME

RESOURCE_GROUP

CLUSTER_NAME

Workflow will:

Build and push Docker image

Deploy new version to AKS automatically

6 Access the App
kubectl get service weather-app-service --watch

Copy the EXTERNAL-IP

Open in browser:

http://EXTERNAL-IP/

http://EXTERNAL-IP/weather

http://EXTERNAL-IP/health

http://EXTERNAL-IP/swagger

🔧 Troubleshooting
ImagePullBackOff → Check ACR integration with AKS

Service not accessible → Wait for LoadBalancer IP (2-5 min)

GitHub Actions failing → Verify GitHub secrets are correct

🧹 Clean Up
Delete all resources to avoid charges:

az group delete --name student-demo --yes --no-wait

What You Achieved
✅ Built and containerized a .NET Web API

✅ Pushed Docker image to Azure Container Registry

✅ Deployed and scaled app on Azure Kubernetes Service

✅ Automated CI/CD pipeline with GitHub Actions

📚 Next Steps
Add a database (Azure SQL / PostgreSQL)

Use ConfigMaps and Secrets in Kubernetes

Set up Application Insights for monitoring

Explore Terraform / Bicep for Infrastructure as Code

This project is perfect for beginners learning cloud-native development with Azure, Kubernetes, and GitHub Actions.
Use ConfigMaps and Secrets in Kubernetes

Add monitoring with Azure Application Insights

Explore Terraform or Bicep for Infrastructure as Code
