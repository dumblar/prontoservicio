from django.contrib.auth.models import User
from django.db import models


class Company(models.Model):
    """
        Company database model
    """
    id = models.AutoField(u'id', primary_key=True)
    name = models.CharField(u'Company Name', max_length=100)
    dni = models.PositiveIntegerField('Company dni', unique=True, blank=True, null=True)
    active = models.BooleanField('Is Active', default=True)

    def __str__(self):
        return self.name


class UserCompany(models.Model):
    """

    """
    user = models.OneToOneField(User, primary_key=True, on_delete=models.CASCADE)
    company = models.ForeignKey(Company, on_delete=models.CASCADE,
                                limit_choices_to={'is_active': True, 'is_staff': False})

    def __str__(self):
        return self.user.__str__()
