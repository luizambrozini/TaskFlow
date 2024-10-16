provider "azurerm" {
  features {}
}

# Resource Group
resource "azurerm_resource_group" "rg" {
  name     = "rg-free-tier-taskflow-db"
  location = "East US"
}

# MySQL Server (Plano Gratuito)
resource "azurerm_mysql_flexible_server" "mysql_server" {
  name                = "taskflowmysql"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  sku_name            = "Standard_B1ms"
  storage_mb          = 5120

  administrator_login          = "taskflow"
  administrator_login_password = "T4skflow2015@"
  version                      = "8.0"

  # Rede privada da Azure (Necessária para MySQL)
  delegated_subnet_id = azurerm_subnet.my_subnet.id

  # Configurações de rede pública
  public_network_access_enabled = true

  # Uso de zona de disponibilidade
  availability_zone = "1"
}

# MySQL Database
resource "azurerm_mysql_flexible_server_database" "mysql_db" {
  name                = "taskflowdb"
  resource_group_name = azurerm_resource_group.rg.name
  server_name         = azurerm_mysql_flexible_server.mysql_server.name
  collation           = "utf8mb4_general_ci"
}

# Subnet para o MySQL Server (necessário para MySQL no Flexible Server)
resource "azurerm_virtual_network" "my_vnet" {
  name                = "my-vnet"
  address_space       = ["10.0.0.0/16"]
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
}

resource "azurerm_subnet" "my_subnet" {
  name                 = "my-subnet"
  resource_group_name  = azurerm_resource_group.rg.name
  virtual_network_name = azurerm_virtual_network.my_vnet.name
  address_prefixes     = ["10.0.1.0/24"]

  delegation {
    name = "delegation"
    service_delegation {
      name    = "Microsoft.DBforMySQL/flexibleServers"
      actions = ["Microsoft.Network/virtualNetworks/subnets/action"]
    }
  }
}

# App Service Plan (Free Tier)
resource "azurerm_app_service_plan" "asp" {
  name                = "asp-taskflow-free"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  sku {
    tier = "Free"
    size = "F1"
  }
}

# App Service for TaskFlow - Deploy from GitHub
resource "azurerm_app_service" "app_service" {
  name                = "taskflow-webapi-free"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.asp.id

  app_settings = {
    "WEBSITE_RUN_FROM_PACKAGE" = "1"
    "MYSQL_CONNECTION_STRING"  = "Server=${azurerm_mysql_flexible_server.mysql_server.fully_qualified_domain_name};Database=${azurerm_mysql_flexible_server_database.mysql_db.name};User Id=taskflow;Password=T4skflow2015@;"
  }

  site_config {
    scm_type                = "GitHub"
    git_repository_url      = "https://github.com/luizambrozini/TaskFlow.git"
    branch                  = "main"
  }
}
