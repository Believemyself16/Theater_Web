<template>
  <v-container fluid class="pa-0 ma-0 black white--text" height="10">
    <!-- thẻ đen để đăng nhập/đăng ký -->
    <div class="d-flex inner justify-end align-center">
      <a class="link" href="">Đăng nhập</a>
      <span class="mx-2 pb-1">|</span>
      <a class="link" href="">Đăng ký</a>
      <a href="">
        <v-img
          height="15"
          max-width="24"
          src="@/assets/union-jack-26119_1280.png"
          class="mx-2"
        >
        </v-img>
      </a>
      <!-- nút đổi ngôn ngữ -->
      <v-button></v-button>
    </div>
  </v-container>
</template>

<style scoped>
.v-application a {
  color: white !important;
}
.inner {
  width: 94%;
  max-width: 96%;
  height: 25px;
}
.link {
  text-decoration: none;
  font-size: 13px;
}
.link:hover {
  text-decoration: underline;
}
</style>
