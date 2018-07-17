"""untitled URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/2.0/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.contrib import admin
from django.urls import path, include
from rest_framework import routers
from rest_framework.authtoken import views

from auth.views import *
from companies.views import CompanyViewSet

router = routers.DefaultRouter()

# Register api urls
router.register(r'users', UserViewSet)
router.register(r'companies', CompanyViewSet)

urlpatterns = [
    path('admin/', admin.site.urls),
    path('api/', include(router.urls)),
    path('api-auth/', include('rest_auth.urls')),
    path('api-auth/token', views.obtain_auth_token),
]

admin.site.site_title = u'Pronto ambulancias'
admin.site.site_header = u'Dashboard Pronto Ambulancias'
