from django.db import models

from companies.models import Company


class Patient(models.Model):
    """
        Patient database model
    """
    id = models.PositiveIntegerField(u'id', primary_key=True)
    name = models.CharField(u'Patient Name', max_length=100)
    age = models.CharField(u'Age', max_length=50)
    eps = models.PositiveSmallIntegerField(u'EPS')
    company = models.ForeignKey(Company, on_delete=models.CASCADE)

    def __str__(self):
        return self.name
