from django.contrib import admin

from .models import *


class UserCompanyInline(admin.StackedInline):
    model = UserCompany


@admin.register(Company)
class CompanyAdmin(admin.ModelAdmin):
    inlines = [UserCompanyInline]

    class Meta:
        verbose_name = u'Company'
        verbose_name_plural = u'Companies'
