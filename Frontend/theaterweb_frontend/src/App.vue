<template>
  <v-app>
    <v-main>
      <LoginAndRegister />
      <Navbar />
      <router-view />
      <Footer />
    </v-main>
  </v-app>
</template>

<script>
import Navbar from "@/components/Navbar.vue";
import Footer from "@/components/Footer.vue";
import LoginAndRegister from "@/components/LoginAndRegister.vue";
export default {
  name: "App",
  components: {
    Navbar,
    Footer,
    LoginAndRegister,
  },
  data: () => ({
    //
  }),
};
</script>

<style></style>
