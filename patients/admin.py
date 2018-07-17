from django.contrib import admin
from company.models import *


class UserCompanyInline(admin.StackedInline):
    model = UserCompany


@admin.register(Company)
class PatientAdmin(admin.ModelAdmin):
    inlines = [UserCompanyInline]