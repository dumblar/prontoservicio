from django.contrib import admin

from .models import *


class UserCompanyInline(admin.StackedInline):
    model = UserCompany


@admin.register(Company)
class CompanyAdmin(admin.ModelAdmin):
    inlines = [UserCompanyInline]

    list_display = ('id', 'name', 'active', 'dni')

    search_fields = ('dni', 'name')

    list_filter = ('active',)

    class Meta:
        verbose_name = u'Company'
        verbose_name_plural = u'Companies'
