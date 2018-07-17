from django.contrib import admin
from .models import *


@admin.register(Patient)
class PatientAdmin (admin.ModelAdmin):
    list_display = ('id', 'name', 'age', 'eps', 'company')
    list_filter = ('eps', 'company')
    search_fields = ('id', 'name')
