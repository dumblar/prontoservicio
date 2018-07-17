from rest_framework import viewsets
from rest_framework.decorators import permission_classes
from rest_framework.permissions import DjangoModelPermissions

from .serializers import *


@permission_classes((DjangoModelPermissions, ))
class CompanyViewSet(viewsets.ModelViewSet):
    queryset = Company.objects.all()
    serializer_class = CompanySerializer
