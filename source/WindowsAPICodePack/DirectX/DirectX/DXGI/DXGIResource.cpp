// Copyright (c) Microsoft Corporation.  All rights reserved.

#include "stdafx.h"
#include "DXGIResource.h"

using namespace Microsoft::WindowsAPICodePack::DirectX::Utilities;
using namespace Microsoft::WindowsAPICodePack::DirectX::Graphics;

ResourcePriority Resource::EvictionPriority::get()
{
    UINT tempoutEvictionPriority;
    Validate::VerifyResult(CastInterface<IDXGIResource>()->GetEvictionPriority(&tempoutEvictionPriority));
    return static_cast<ResourcePriority>(tempoutEvictionPriority);
}

void Resource::EvictionPriority::set(ResourcePriority value)
{
    Validate::VerifyResult(CastInterface<IDXGIResource>()->SetEvictionPriority(static_cast<UINT>(value)));
}

IntPtr Resource::.SharedHandle::get()
{
    HANDLE tempout.SharedHandle;
    Validate::VerifyResult(CastInterface<IDXGIResource>()->Get.SharedHandle(&tempout.SharedHandle));
    return IntPtr(tempout.SharedHandle);
}

UsageOptions Resource::UsageOptions::get()
{
    DXGI_USAGE tempoutUsage;
    Validate::VerifyResult(CastInterface<IDXGIResource>()->GetUsage(&tempoutUsage));
	return safe_cast<Graphics::UsageOptions>(tempoutUsage);
}
