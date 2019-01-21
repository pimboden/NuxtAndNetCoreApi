<template>
    <ul class="navbar-nav">
      <li class="nav-item">
        <nuxt-link class="nav-link" :to="$i18n.path('')" exact>
            {{ $t('links.home') }}
        </nuxt-link>
      </li>
      <li class="nav-item">
        <nuxt-link class="nav-link" :to="$i18n.path('news')" exact>
          {{ $t('links.news') }}
        </nuxt-link>
      </li>
      <li class="nav-item">
        <nuxt-link class="nav-link" :to="$i18n.path('videos')" exact>
          {{ $t('links.videos') }}
        </nuxt-link>
      </li>
      <li class="nav-item">
        <nuxt-link class="nav-link" :to="$i18n.path('articles')" exact>
          {{ $t('links.articles') }}
        </nuxt-link>
      </li>
    </ul>
</template>

<style>

</style>